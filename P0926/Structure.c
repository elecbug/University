#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} AVLN;

typedef struct stack_node
{
	AVLN* data;
	struct stack_node* next;
} StackNode;