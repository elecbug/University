#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <pthread.h>

#define SIZE 500000
#define CASE 4

/*
* 넘겨줄 파라미터를 단일 구조체화 -> void* 하나로 통합해서 넘겨주기 용이하게 하기 위해서
*/
typedef struct params
{
    int* arr;  // 정렬할 목록
    int left;  // 좌측 피봇
    int right; // 우측 피봇
    int is_threaded;    // 의미는 스레드로 실행할 지 여부,
                        // 0 이하면 스레드 분기를 하지 않도록 하여 계속 감소함
} Params;

/*
* 실행될 함수, 일반 실행되기도 하고, pthread로 실행되기도 함
* params<input> params* 구조체로 변경되어 래핑된 매개변수를 받는 용도
*/
void* recursive_merge_sort(void* input)
{
    Params* params = (Params*)input;

    // 병합 정렬을 위한 중간 피봇
    int mid = (params->right + params->left) / 2;

    // 일반적인 병합정렬 루틴 진입
    if (params->right > params->left)
    {
        // 분할 후 두 부분의 변수를 각각 래핑
        Params left = {params->arr, params->left, mid, params->is_threaded - 1};
        Params right = {params->arr, mid + 1, params->right, params->is_threaded - 1};

        // 스레드 여부 필드만큼의 재귀 함수를 멀티 스레드로 실행
        if (params->is_threaded > 0)
        {
            pthread_t sub_l;
            int status_l;

            // 좌측 분할을 스레드로 구동하고
            pthread_create(&sub_l, NULL, recursive_merge_sort, (void*)&left);
            // 현재 스레드는 우측 분할을 구동한 뒤
            recursive_merge_sort(&right);  

            // 좌측 분할이 종료될 때 까지 대기한다.
            pthread_join(sub_l, (void**)&status_l);
        }
        // 일반 실행 루틴
        else
        {
            recursive_merge_sort(&left);
            recursive_merge_sort(&right);
        }
       
        // 일반적인 부분 병합정렬 루틴
        int* temp = (int*)malloc(sizeof(int) * (params->right - params->left + 1));
        int i = params->left, j = mid + 1, k = 0;

        while (i <= mid && j <= params->right)
        {
            if (params->arr[i] < params->arr[j])
                temp[k++] = params->arr[i++];
            else
                temp[k++] = params->arr[j++];
        }
        while (k < params->right - params->left + 1)
        {
            if (i <= mid)
                temp[k++] = params->arr[i++];
            else
                temp[k++] = params->arr[j++];
        }

        for (int in = 0; in < params->right - params->left + 1; in++)
        {
            params->arr[in + params->left] = temp[in];
        }

        free(temp);
    }
}

/*
* 종료 후 순회하며 정렬이 완료 되어있는지 확인하는 함수
*/
char* order_check(int* arr, int size)
{
    for (int i = 0; i < size - 1; i++)
    {
        if (arr[i] > arr[i + 1])
        {
            return "error";
        }
    }

    return "ok";
}

int main(int argc, char* argv[])
{
    int arr[CASE][SIZE] = {};
   
    // 몇가지 케이스로 병합 정렬을 수행
    /* 케이스
    * 부분 랜덤
    * 역 정렬
    * 정렬 됨
    * 전부 1
    */
    for (int i = 0; i < SIZE; i++)
    {
        arr[0][SIZE] = i % 2 ? i * 2: i;
        arr[1][SIZE] = SIZE - i;
        arr[2][SIZE] = i;
        arr[3][SIZE] = 1;
    }

    // 재귀 깊이 세팅, 해당 깊이까지만 멀티 스레드로 실행
    int n = atoi(argv[1]);

    // 최종 평균 시간 변수
    double sum = 0;

    for (int i = 0; i < CASE; i++)
    {
        // 현재 시간을 기반으로 시작 시간 세팅
        struct timeval start;
        gettimeofday(&start, NULL);
       
        // 넘겨줄 파라미터 래핑
        Params params = {arr[i], 0, SIZE - 1, n};

        printf("case %d start sorting...\n", i + 1);

        // 병합 정렬
        recursive_merge_sort(&params);

        // 현재 시간을 기반으로 종료 시간 세팅
        struct timeval end;
        gettimeofday(&end, NULL);

        // 최종 평균 시간 측정을 위해 합산
        double subsum = ((end.tv_sec * (long)1000000 + end.tv_usec)
            - (start.tv_sec * (long)1000000 + start.tv_usec)) / (double)1000;
        sum += subsum;

        // 각 루틴의 시간 출력
        printf("%lf msec later\n", subsum);

        // 혹시 정렬이 제대로 안 되었을까 (즉, 데이터가 더럽혀졌는가)
        printf("check %s\n", order_check(arr[i], SIZE));
    }

    // 최종 평균 시간
    printf("average time: %lf\n", sum / (CASE));
}

