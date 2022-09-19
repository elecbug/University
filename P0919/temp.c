#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef int element;

typedef struct node 
{
	struct node* parent;
	struct node* left;
	struct node* right;
	element data;
} NODE;

typedef struct tree
{
	struct node* head;
	struct node* deep;
};