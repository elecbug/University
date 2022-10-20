#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} TreeNode;

typedef struct stack_node
{
	TreeNode* data;
	struct stack_node* next;
} StackNode;