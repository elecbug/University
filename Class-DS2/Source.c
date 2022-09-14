#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef int element;

typedef struct array 
{
	element* data;
	size_t size;
	size_t capacity;

} ARRAY;

void create_array(ARRAY** array, size_t size)
{
	*array = (ARRAY*)malloc(sizeof(ARRAY));
	(*array)->size = size;
	(*array)->capacity = 0;
	(*array)->data = (element*)malloc(sizeof(element) * size);
}

void insert_array(ARRAY* array, size_t index, element data) 
{
	if (index >= 0 && index <= array->capacity && array->capacity < array->size)
	{
		memcpy(&array->data[index + 1], &array->data[index], sizeof(element) * (array->capacity - index));
		array->data[index] = data;
		array->capacity++;
	}
}

void delete_array(ARRAY* array, size_t index)
{
	if (index >= 0 && index <= array->capacity && array->capacity > 0)
	{
		memcpy(&array->data[index], &array->data[index + 1], sizeof(element) * (array->capacity - index - 1));
	}
}

int main()
{
	ARRAY* array = NULL;
	create_array(&array, 10);
	for (int i = 0; i < 10; i++)
		insert_array(array, 0, i);
	delete_array(array, 0);
	// a
}