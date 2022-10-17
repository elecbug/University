#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
	int height;
} TreeNode;

int recursive_inorder(TreeNode* head)
{
	int height;
	if (head != NULL)
	{
		int i1 = recursive_inorder(head->left);
		printf("%d - ", head->data);
		int i2 = recursive_inorder(head->right);
		height = i1 > i2 ? i1 : i2;
	}
	if (head == NULL) return -1;
	else return height + 1;
}

TreeNode* search_BST(TreeNode* root, int target)
{
	while (1)
	{
		if (root == NULL)
		{
			return NULL;
		}
		else if (target == root->data)
		{
			return root;
		}
		else if (target > root->data)
		{
			root = root->right;
		}
		else if (target < root->data)
		{
			root = root->left;
		}
	}
}

TreeNode* create_BST()
{
	TreeNode* result = (TreeNode*)malloc(sizeof(TreeNode));
	result->left = NULL;
	result->right = NULL;

	return result;
}

TreeNode* insert_BST(TreeNode* root, int data)
{
	TreeNode* result = root;

	if (root == NULL)
	{
		root = create_BST();
		root->data = data;
		root->height = 0;

		return root;
	}
	while (1)
	{
		if (root->data == data)
		{
			break;
		}
		else if (root->data < data)
		{
			if (root->right == NULL)
			{
				root->right = create_BST();
				root->right->data = data;
				root->right->height = root->height + 1;

				break;
			}
			else
			{
				root = root->right;
			}
		}
		else if (root->data > data)
		{
			if (root->left == NULL)
			{
				root->left = create_BST();
				root->left->data = data;
				root->left->height = root->height + 1;

				break;
			}
			else
			{
				root = root->left;
			}
		}
	}
	printf("{%d}\n", recursive_inorder(result));

	return result;
}

int main()
{
	TreeNode* root = NULL;
	root = insert_BST(root, 5);
	root = insert_BST(root, 6);
	root = insert_BST(root, 7);
	root = insert_BST(root, 4);
	root = insert_BST(root, 3);
	root = insert_BST(root, 2);
	root = insert_BST(root, 1);
}
