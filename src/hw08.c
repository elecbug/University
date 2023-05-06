#include <stdio.h>
#include <pthread.h>

int sum = 0;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void* add_sum(void* params)
{
    pthread_mutex_lock(&mutex);
    {/*critical setction*/
        printf("now sum: %d\n", ++sum);
    }
    pthread_mutex_unlock(&mutex);
}

int main()
{
    pthread_t ts[10];
    int state;
    for (int i = 0; i < 10; i++)
    {
        pthread_create(&ts[i], NULL, add_sum, NULL);
    }
    for (int i = 0; i < 10; i++)
    {
        pthread_join(ts[i], (void**)state);
    }
    printf("value of sum: %d\n", sum);
}