#pragma once

#define TRUE 1;
#define FALSE 0;
typedef char Bool;

typedef int element;

typedef struct array_head 
{
	element* address;
	size_t count;
} Array;

typedef struct bst_node
{
	element data;
	struct bst_node* left;
	struct bst_node* right;
} BSTN;

typedef struct avl_node
{
	element data;
	struct avl_node* left;
	struct avl_node* right;
} AVLN;

typedef struct time_saver
{
	long insert;
	long find;
} TSaver;