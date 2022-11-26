#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int unsorted_linear(int try, int arr[], int n, int key, int* count)
{
	printf("find %d\n", key);

	int pivot = 0;
	
	while (pivot < n)
	{
		(*count)++;

		printf("%4d try. %4d: arr[%d]: %d\n", try, *count, pivot, arr[pivot]);

		if (arr[pivot] == key) return pivot;
		else pivot++;
	}

	return -1;
}

int sorted_linear(int try, int arr[], int n, int key, int* count)
{
	printf("find %d\n", key);

	int pivot = 0;

	while (pivot < n && arr[pivot] <= key)
	{
		(*count)++;

		printf("%4d try. %4d: arr[%d]: %d\n", try, *count, pivot, arr[pivot]);

		if (arr[pivot] == key) return pivot;
		else pivot++;
	}

	return -1;
}

int binary_search(int try, int arr[], int begin, int end, int key, int* count)
{
	(*count)++;

	printf("find %d\n", key);

	int pivot = (end + begin) / 2;

	if (end <= begin) return -1;

	printf("%4d try. %4d: arr[%d]: %d\n", try, *count, pivot, arr[pivot]);

	if (arr[pivot] == key) return pivot;
	else if (arr[pivot] > key) return binary_search(try, arr, begin, pivot - 1, key, count);
	else if (arr[pivot] < key) return binary_search(try, arr, pivot + 1, end, key, count);
	else return -1;
}

void shuffle(int* arr, int n)
{
	for (int i = 0; i < n; i++)
	{
		srand(time(0) + rand());

		int j = rand() % n;
		int temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}
}

int main()
{
	int unsorted[1000];
	int sorted[1000];

	for (int i = 0; i < 1000; i++)
	{
		unsorted[i] = i * 2 + 1;
		sorted[i] = i * 2 + 1;
	}

	shuffle(unsorted, 1000);

	int counter[3] = { 0 };
	double sum[3] = { 0 };

	for (int i = 0; i < 100; i++)
	{
		int randn = rand() % 4000 + 1;

		printf("last index: arr[%d]\n\n", unsorted_linear(i + 1, unsorted, sizeof(unsorted) / 4, randn, &counter[0]));

		printf("last index: arr[%d]\n\n", sorted_linear(i + 1, sorted, sizeof(sorted) / 4, randn, &counter[1]));

		printf("last index: arr[%d]\n\n", binary_search(i + 1, sorted, 0, sizeof(sorted) / 4 - 1, randn, &counter[2]));

		for (int j = 0; j < 3; j++)
		{
			sum[j] += counter[j];
			counter[j] = 0;
		}
	}

	printf("unsorted_linear's average: %llf\n", sum[0] / 100);
	printf("sorted_linear's average: %llf\n", sum[1] / 100);
	printf("binary_search's average: %llf\n", sum[2] / 100);

	/*printf("last index: arr[%d]\n\n", unsorted_linear(unsorted, sizeof(unsorted) / 4, 5, &counter[i++]));
	printf("last index: arr[%d]\n\n", unsorted_linear(unsorted, sizeof(unsorted) / 4, 10, &counter[i++]));

	printf("last index: arr[%d]\n\n", sorted_linear(sorted, sizeof(sorted) / 4, 5, &counter[i++]));
	printf("last index: arr[%d]\n\n", sorted_linear(sorted, sizeof(sorted) / 4, 10, &counter[i++]));

	printf("last index: arr[%d]\n\n", binay_search(sorted, 0, sizeof(sorted) / 4 - 1, 5, &counter[i++]));
	printf("last index: arr[%d]\n\n", binay_search(sorted, 0, sizeof(sorted) / 4 - 1, 10, &counter[i++]));*/
}