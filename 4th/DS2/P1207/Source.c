#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#define SIZE 7

void swap(int* a, int* b)
{
	*a ^= *b ^= *a ^= *b;
}

void bubble(int* arr, int len)
{
	printf("default:\n");
	for (int i = 0; i < len; i++)
	{
		printf("%d -> ", arr[i]);
	}
	printf("\n");

	int count = 0;
	printf("bubble\n");

	for (int i = 0; i < len; i++)
	{
		for (int j = 0; j < len - 1 - i; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				swap(&arr[j], &arr[j + 1]);
			}

			for (int i = 0; i < len; i++)
			{
				printf("%d -> ", arr[i]);
			}
			printf("\n");

			count++;
		}
	}

	printf("count: %d\n\n", count);
}

void selection(int* arr, int len)
{
	printf("default:\n");
	for (int i = 0; i < len; i++)
	{
		printf("%d -> ", arr[i]);
	}
	printf("\n");

	int count = 0;
	printf("selection\n");

	for (int i = 0; i < len; i++)
	{
		int max = 0;

		for (int j = 1; j < len - i; j++)
		{
			if (arr[max] < arr[j])
			{
				max = j;
			}

			for (int i = 0; i < len; i++)
			{
				printf("%d -> ", arr[i]);
			}
			printf("\n");
			count++;
		}

		if (max != len - 1 - i)
		{
			swap(&arr[len - 1 - i], &arr[max]);
		}
	}

	printf("count: %d\n\n", count);
}

void insertion(int* arr, int len)
{
	printf("default:\n");
	for (int i = 0; i < len; i++)
	{
		printf("%d -> ", arr[i]);
	}
	printf("\n");

	int count = 0;
	printf("insertion\n");

	for (int i = 1; i < len; i++)
	{
		for (int j = i - 1; j >= 0; j--)
		{
			if (arr[j] > arr[j + 1])
			{
				swap(&arr[j], &arr[j + 1]);
			}

			for (int i = 0; i < len; i++)
			{
				printf("%d -> ", arr[i]);
			}
			printf("\n");
			count++;
		}
	}

	printf("count: %d\n\n", count);
}

void fix_bubble(int* arr, int len)
{
	printf("default:\n");
	for (int i = 0; i < len; i++)
	{
		printf("%d -> ", arr[i]);
	}
	printf("\n");

	int count = 0;
	printf("fix bubble\n");

	for (int i = 0; i < len; i++)
	{
		int end = 1;
		for (int j = 0; j < len - 1 - i; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				swap(&arr[j], &arr[j + 1]);
				end = 0;
			}

			for (int i = 0; i < len; i++)
			{
				printf("%d -> ", arr[i]);
			}
			printf("\n");
			count++;
		}
		if (end == 1)
		{
			printf("end bubble sorting\n");
			break;
		}
	}

	printf("count: %d\n\n", count);
}


int main()
{
	int base[SIZE];
	for (int k = 0; k < SIZE; k++)
	{
		srand(time(0) + rand());
		base[k] = rand() % 100 + 1;
	}

	for (int j = 0; j < 4; j++)
	{
		int arr[SIZE];
		for (int k = 0; k < SIZE; k++)
		{
			srand(time(0) + rand());
			arr[k] = base[k];
		}
		

		switch (j)
		{
		case 0:
			bubble(arr, SIZE);
			break;
		case 1:
			selection(arr, SIZE);
			break;
		case 2:
			insertion(arr, SIZE);
			break;
		case 3:
			fix_bubble(arr, SIZE);
			break;
		}
	}
}