#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int unsorted_linear(int arr[], int n, int key, int* count)
{
	printf("find %d\n", key);

	int pivot = 0;
	
	while (pivot < n)
	{
		*count++;

		printf("%try %4d: arr[%d]: %d\n", *count, pivot, arr[pivot]);

		if (arr[pivot] == key) return pivot;
		else pivot++;
	}

	return -1;
}

int sorted_linear(int arr[], int n, int key, int* count)
{
	printf("find %d\n", key);

	int pivot = 0;

	while (pivot < n && arr[pivot] <= key)
	{
		*count++;

		printf("%try %4d: arr[%d]: %d\n", *count, pivot, arr[pivot]);

		if (arr[pivot] == key) return pivot;
		else pivot++;
	}

	return -1;
}

int binay_search(int arr[], int begin, int end, int key, int* count)
{
	*count++;

	printf("find %d\n", key);

	int pivot = (end + begin) / 2;

	if (end == begin) return -1;

	printf("%try %4d: arr[%d]: %d\n", *count, pivot, arr[pivot]);

	if (arr[pivot] == key) return pivot;
	else if (arr[pivot] > key) return binay_search(arr, begin, pivot - 1, key, count);
	else if (arr[pivot] < key) return binay_search(arr, pivot + 1, end, key, count);
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

	int counter[6] = {0};
	int i = 0;

	printf("last index: arr[%d]\n\n", unsorted_linear(unsorted, sizeof(unsorted) / 4, 5, &counter[i++]));
	printf("last index: arr[%d]\n\n", unsorted_linear(unsorted, sizeof(unsorted) / 4, 10, &counter[i++]));

	printf("last index: arr[%d]\n\n", sorted_linear(sorted, sizeof(sorted) / 4, 5, &counter[i++]));
	printf("last index: arr[%d]\n\n", sorted_linear(sorted, sizeof(sorted) / 4, 10, &counter[i++]));

	printf("last index: arr[%d]\n\n", binay_search(sorted, 0, sizeof(sorted) / 4 - 1, 5, &counter[i++]));
	printf("last index: arr[%d]\n\n", binay_search(sorted, 0, sizeof(sorted) / 4 - 1, 10, &counter[i++]));
}