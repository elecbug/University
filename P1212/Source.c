#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define SIZE 8

typedef struct Node
{
	int left;
	int right;
	struct Node* next;
} Node;

void push(Node* node, int left, int right)
{
	Node* temp = (Node*)malloc(sizeof(Node));
	temp->left = left;
	temp->right = right;
	temp->next = node->next;
	node->next = temp;
}
void pop(Node* node, int* left, int* right)
{
	Node* del = node->next;
	node->next = node->next->next;

	*left = del->left;
	*right = del->right;

	free(del);
}
void top(Node* node, int* left, int* right)
{

	Node* del = node->next;
	
	*left = del->left;
	*right = del->right;
}

void recursive_merge_sort(int* arr, int left, int right)
{
	int mid = (right + left) / 2;

	if (right > left)
	{
		recursive_merge_sort(arr, left, mid);
		recursive_merge_sort(arr, mid + 1, right);

		int* temp = (int*)malloc(sizeof(int) * (right - left + 1));
		int i = left, j = mid + 1, k = 0;

		while (i <= mid && j <= right)
		{
			if (arr[i] < arr[j])
				temp[k++] = arr[i++];
			else
				temp[k++] = arr[j++];
		}
		while (k < right - left + 1)
		{
			if (i <= mid)
				temp[k++] = arr[i++];
			else
				temp[k++] = arr[j++];
		}

		for (int in = 0; in < right - left + 1; in++)
		{
			arr[in + left] = temp[in];
		}

		free(temp);

		for (int i = 0; i < SIZE; i++)
		{
			printf("%d -> ", arr[i]);
		}
		printf("\n");
	}
}
void iterative_merge_sort(int* arr, int left, int right)
{
	Node* stack = (Node*)malloc(sizeof(Node));
	stack->next = NULL;

	while (1)
	{
		push(stack, left, right);
		if (left < right)
		{
			top(stack, &left, &right);
			int mid = (right + left) / 2;

			if (mid + 1 < right)
			{
				push(stack, mid + 1, right);
			}
			if (left < mid)
			{
				push(stack, left, mid);
			}
			top(stack, &left, &right);
		}
	}

	while (stack->next != NULL)
	{
		pop(stack, &left, &right);

		int* temp = (int*)malloc(sizeof(int) * (right - left + 1));
		int mid = (right + left) / 2;
		int i = left, j = mid + 1, k = 0;

		while (i <= mid && j <= right)
		{
			if (arr[i] < arr[j])
				temp[k++] = arr[i++];
			else
				temp[k++] = arr[j++];
		}
		while (k < right - left + 1)
		{
			if (i <= mid)
				temp[k++] = arr[i++];
			else
				temp[k++] = arr[j++];
		}

		for (int in = 0; in < right - left + 1; in++)
		{
			arr[in + left] = temp[in];
		}

		free(temp);

		for (int i = 0; i < SIZE; i++)
		{
			printf("%d -> ", arr[i]);
		}
		printf("\n");
	}
}

int main()
{
	int arr1[SIZE] = { 1,3,5,6,4,2,0,7 };
	int arr2[SIZE] = { 1,3,5,6,4,2,0,7 };

	recursive_merge_sort(arr1, 0, SIZE - 1);
	iterative_merge_sort(arr2, 0, SIZE - 1);

	for (int i = 0; i < SIZE; i++)
	{
		printf("%d -> ", arr1[i]);
	}
	printf("\n");
	for (int i = 0; i < SIZE; i++)
	{
		printf("%d -> ", arr2[i]);
	}
	printf("\n");
}