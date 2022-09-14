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

typedef struct node
{
	element data;
	struct node* next;
} NODE;

typedef struct list
{
	NODE* head;
	NODE* tail;
	size_t size;
} LIST;

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

void create_list(LIST** list)
{
	*list = (LIST*)malloc(sizeof(LIST));
	(*list)->head = (NODE*)malloc(sizeof(NODE));
	(*list)->tail = (NODE*)malloc(sizeof(NODE));
	(*list)->head->next = (*list)->tail;
	(*list)->tail->next = NULL;
}

void insert_list(LIST* list, size_t index, element data)
{
	if (index >= 0 && index <= list->size)
	{
		NODE* loc = list->head;

		for (int i = 0; i < index; i++)
		{
			loc = loc->next;
		}
		NODE* new_node = (NODE*)malloc(sizeof(NODE));

		new_node->data = data;
		new_node->next = loc->next;
		loc->next = new_node;
		
		list->size++;
	}
}

void delete_list(LIST* list, size_t index)
{
	if (index >= 0 && index < list->size)
	{
		NODE* loc = list->head;

		for (int i = 0; i < index; i++)
		{
			loc = loc->next;
		}
		NODE* next = loc->next->next;

		free(loc->next);
		loc->next = next;

		list->size--;
	}
}

int main()
{
	ARRAY* array = NULL;
	create_array(&array, 10);
	for (int i = 0; i < 10; i++)
		insert_array(array, 0, i);
	delete_array(array, 1);
	// a

	LIST* list = NULL;
	create_list(&list);
	for (int i = 0; i < 10; i++)
		insert_list(list, 0, i);
	delete_list(list, 1);
}