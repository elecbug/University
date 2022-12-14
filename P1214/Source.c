#include <stdio.h>
#include <stdlib.h>
#define SIZE 10

void swap(int* x, int* y)
{
	int temp = *x;
	*x = *y;
	*y = temp;
}

int middle(int* arr, int start, int end)
{
	int f = arr[start];
	int s = arr[(end + start) / 2];
	int t = arr[end];

	if (f < s)
	{
		if (s < t)
		{
			return (end + start) / 2;
		}
		else if (f < t)
		{
			return end;
		}
		else
		{
			return start;
		}
	}
	else // s < f
	{
		if (f < t)
		{
			return start;
		}
		else if (s < t)
		{
			return end;
		}
		else
		{
			return (end + start) / 2;
		}
	}
}

void i_sort(int* arr, int start, int end)
{
	for (int i = start + 1; i <= end; i++)
	{
		for (int j = i; j > 0; j--)
		{
			if (arr[j] < arr[j - 1])
			{
				swap(&arr[j], &arr[j - 1]);
			}
		}
	}
}

void q_sort(int* arr, int start, int end)
{
	if (start < end)
	{
		int f_start = start, f_end = end;

		int pivot = middle(arr, start, end);
		swap(&arr[end], &arr[pivot]);
		pivot = end;

		end--;

		while (start <= end)
		{
			while (arr[start] < arr[pivot])
			{
				start++;
			}
			while (arr[pivot] < arr[end])
			{
				end--;
			}
			swap(&arr[start], &arr[end]);
		}
		swap(&arr[start], &arr[end]);
		swap(&arr[pivot], &arr[end + 1]);

		for (int i = 0; i < SIZE; i++)
		{
			printf("%d -> ", arr[i]);
		}
		printf("\n");

		if (end - f_start > 10)
			q_sort(arr, f_start, end);
		else
			i_sort(arr, f_start, end);
		if (f_end - (end + 2) > 10)
			q_sort(arr, end + 2, f_end);
		else
			i_sort(arr, end + 2, f_end);
	}
}

int main()
{
	int arr[] = { 0,2,4,6,8,9,7,5,3,1 };

	q_sort(arr, 0, SIZE - 1);

	for (int i = 0; i < SIZE; i++)
	{
		printf("%d -> ", arr[i]);
	}
	printf("\n");
}