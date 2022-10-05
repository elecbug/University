#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} TreeNode;

void recursive_inorder(TreeNode* head)
{
	if (head != NULL)
	{
		recursive_inorder(head->left);
		printf("%d - ", head->data);
		recursive_inorder(head->right);
	}
}

TreeNode* create_BST()
{
	TreeNode* result = (TreeNode*)malloc(sizeof(TreeNode));
	result->left = NULL;
	result->right = NULL;

	return result;
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

TreeNode* insert_BST(TreeNode* root, int data)
{
	TreeNode* result = root;

	if (root == NULL)
	{
		root = create_BST();
		root->data = data;

		return root;
	}
	while (1)
	{
		if (root->data == data) 
		{
			return result;
		}
		else if (root->data < data)
		{
			if (root->right == NULL)
			{
				root->right = create_BST();
				root->right->data = data;

				return result;
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

				return result;
			}
			else
			{
				root = root->left;
			}
		}
	}
}

TreeNode* random_BST(int index)
{
	TreeNode* result = NULL;
	for (int i = 0; i < index; i++)
	{
		srand(time(0) + rand());
		int r = rand() % 10;
		if (search_BST(result, r) != NULL) 
		{
			index++;
			continue;
		}
		printf("%d ", r);
		result = insert_BST(result, r);
	}
	printf("\n");
	return result;
}

int main()
{
	int data[] = { 17,2,7,35,12,30 };
	TreeNode* root = NULL;

	root = random_BST(7);

	recursive_inorder(root);
}
