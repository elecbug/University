/*
#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} TreeNode;

TreeNode* create_BST()
{
	TreeNode* result = (TreeNode*)malloc(sizeof(TreeNode));
	result->left = NULL;
	result->right = NULL;

	return result;
}

void insert_BST(TreeNode* root, int data)
{

}

int main()
{
	int data[] = { 17,2,7,35,12,30 };
	TreeNode* root = create_BST();

	for (int i = 0; i < sizeof(data) / 4; i++)
	{
		insert_BST(root, data[i]);
	}
}
*/