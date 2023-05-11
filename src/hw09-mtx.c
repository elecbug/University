#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <pthread.h>
#include <time.h>

#define RN 40   // 읽기 스레드 수
#define BUFSZ 128    // 최대 입력 가능한 글자 수
#define OUTPUT "output" // 출력 파일 이름

typedef enum {READ, WAIT} STATE;

typedef struct DATA
{
    char value[BUFSZ]; // 읽기 기준 쓸 위치(buff + 자기 num)
    int num;         // 읽기 기준 자신의 스레드 번호
    STATE flag;      // 읽기 기준 자신이 읽을 차례인지 확인하는 플래그
} DATA;

DATA read_data[RN]; // 읽기의 데이터와 쓰기의 데이터

pthread_mutex_t rw_mutex; // 읽기 쓰기 간의 공유 mutex
char buff[BUFSZ];   // 공유 버퍼
clock_t tick;   // 다시 쓰기까지 걸린 시간

void* reader(void* params)
{
    while (1)
    {
        pthread_mutex_lock(&rw_mutex);   

        ((DATA*)params)->flag = WAIT; // 읽었으니 대기 모드로 바꿈
        
        sprintf(((DATA*)params)->value, "%s-%d.txt", OUTPUT, ((DATA*)params)->num); // 자기 쓸 위치 자기 value에 복사해옴
        FILE* fp = fopen(((DATA*)params)->value, "a+"); // 파일 오픈

        fprintf(fp, "%s\r\n", buff); // 버퍼의 내용을 씀
        
        fclose(fp); // 닫기

        pthread_mutex_unlock(&rw_mutex);

        while(((DATA*)params)->flag == WAIT) { /* printf("%d lock", ((DATA*)params)->num); */ }
    }
}

void* writer(void* params) 
{
    while (1)
    {
        // 읽기 쪽이 하나도 진입하지 않아야 가능
        pthread_mutex_lock(&rw_mutex);

        printf("Waiting time (to rewrite): %.6lf\n", (clock() - tick) / (float)10000000);
        
        scanf("%s", buff); // 카피할 파일 이름

        tick = clock();

        if (memcmp(buff, "exit", 4) == 0) return;
        for (int i = 0; i < RN; i++)
        {
            read_data[i].flag = READ; // 새로 썼으니 읽기 모드로 바꿈
        }

        pthread_mutex_unlock(&rw_mutex);

        // 하나라도 읽지 못했다면 멈춤
        for (int i = 0; i < RN; i++)
        {
            if (read_data[i].flag == READ)
            {
                i = -1;
            }
        }
    }
}

int main()
{
    // 스레드 타입
    pthread_t thread_r[RN], thread_w;

    // mutex 초기화
    pthread_mutex_init(&rw_mutex, NULL);

    tick = clock();
    pthread_create(&thread_w, NULL, writer, NULL);
    
    // 읽기 스레드들 초기화 및 시작 -> 쓰기 스레드 시작
    for (int i = 0; i < RN; i++)
    {
        read_data[i].num = i;
        read_data[i].flag = READ;
        pthread_create(&thread_r[i], NULL, reader, (void *)&read_data[i]);
    }

    // 쓰기 스레드 검사
    pthread_join(thread_w, NULL);

    // mutex 파괴
    pthread_mutex_destroy(&rw_mutex);
}