#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} TreeNode;

void recursive_preorder(TreeNode* head)
{
	if (head != NULL)
	{
		recursive_preorder(head->left);
		printf("%d - ", head->data);
		recursive_preorder(head->right);
	}
}

TreeNode* create()
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

TreeNode* insert(TreeNode* root, int data)
{
	TreeNode* result = root;

	if (root == NULL)
	{
		root = create();
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
				root->right = create();
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
				root->left = create();
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

TreeNode* find_max(TreeNode* root)
{
	while (root->right != NULL)
	{
		root = root->right;
	}

	return root;
}

TreeNode* find_min(TreeNode* root)
{
	while (root->left != NULL)
	{
		root = root->left;
	}

	return root;
}

TreeNode* pre_delete_BST(TreeNode* root, int data)
{
	TreeNode* temp;
	if (root == NULL)
		printf("Element not there in tree\n");
	else if (data < root->data)
		root->left = pre_delete_BST(root->left, data);
	else if (data > root->data)
		root->right = pre_delete_BST(root->right, data);
	else
	{
		if (root->left && root->right)
		{
			temp = find_max(root->left);
			root->data = temp->data;
			root->left = pre_delete_BST(root->left, root->data);
		}
		else
		{
			temp = root;
			if (root->left == NULL)
				root = root->right;
			else if (root->right == NULL)
				root = root->left;
			free(temp);
		}
	}
	return root;
}

TreeNode* post_delete_BST(TreeNode* root, int data)
{
	TreeNode* temp;
	if (root == NULL)
		printf("Element not there in tree\n");
	else if (data < root->data)
		root->left = post_delete_BST(root->left, data);
	else if (data > root->data)
		root->right = post_delete_BST(root->right, data);
	else
	{
		if (root->left && root->right)
		{
			temp = find_min(root->right);
			root->data = temp->data;
			root->right = post_delete_BST(root->right, root->data);
		}
		else
		{
			temp = root;
			if (root->left == NULL)
				root = root->right;
			else if (root->right == NULL)
				root = root->left;
			free(temp);
		}
	}
	return root;
}


int main()
{
	int data[] = { 40,20,80,50,100,70,60 };
	TreeNode* root = NULL;
	for (int i = 0; i < 7; i++)
	{
		root = insert(root, data[i]);
	}

	root = post_delete_BST(root, 80);

	recursive_preorder(root);
}
