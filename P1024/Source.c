#include <stdio.h>
#include <stdlib.h>

typedef struct heap
{
	int* arr;
	int capacity;
	int count;
	int heap_type;
} Heap;

int Parent(Heap* h, int i) 
{
	if (i <= 0 || i >= h->count)
		return -1;
	return (i - 1) / 2;
}

int LeftChild(Heap* h, int i) 
{
	int left = 2 * i + 1;
	if (left >= h->count)
		return -1;
	return left;
}

int RightChild(Heap* h, int i) 
{
	int right = 2 * i + 2;
	if (right >= h->count)
		return -1;
	return right;
}

Heap* CreateHeap(int capacity, int heap_type)
{
	Heap* h = (Heap*)malloc(sizeof(Heap));
	if (h == NULL) 
	{
		printf("Memory Error");
		return;
	}
	h->heap_type = heap_type;
	h->count = 0;
	h->capacity = capacity;
	h->arr = (int*)malloc(sizeof(int) * h->capacity);
	if (h->arr == NULL) {
		printf("Memory Error");
		return;
	}
	return h;
}

int main() 
{

}