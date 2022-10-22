#include <stdio.h>
#include <stdlib.h>
#define max(x, y) (x > y ? x : y)

typedef struct AVLTreeNode {
	int data;
	struct AVLTreeNode* left;
	struct AVLTreeNode* right;
} TreeNode;

int height(TreeNode* node)
{
	if (node == NULL) return -1;
	else return max(height(node->left), height(node->right)) + 1;
}

TreeNode* srLeft(TreeNode* X)
{
	TreeNode* W = X->right;
	X->right = W->left;
	W->left = X;
	return W;
}

TreeNode* srRight(TreeNode* W)
{
	TreeNode* X = W->left;
	W->left = X->right;
	X->right = W;
	return X;
}

TreeNode* create()
{
	TreeNode* result = (TreeNode*)malloc(sizeof(TreeNode));
	result->left = NULL;
	result->right = NULL;

	return result;
}

void inorder(TreeNode* root, int height)
{
	if (root != NULL)
	{
		char* str[] = { "  ", "→" };
		for (int i = 0; i < height; i++)
		{
			printf("%s", str[i == height - 1]);
		}
		printf("%2d\n", root->data);
		inorder(root->left, height + 1);
		inorder(root->right, height + 1);
	}
}

TreeNode* check_violation(TreeNode* node, int data)
{
	int balance = height(node->left) - height(node->right);

	if (balance > 1 && node->left->data > data)
	{
		// LL
		printf("LL violation\n");
		node = srRight(node);
	}
	else if (balance < -1 && node->right->data < data)
	{
		// RR
		printf("RR violation\n");
		node = srLeft(node);
	}
	else if (balance > 1 && node->left->data < data)
	{
		// LR
		printf("LR violation\n");
		node->left = srLeft(node->left);
		node = srRight(node);
	}
	else if (balance < -1 && node->right->data > data)
	{
		// RL
		printf("RL violation\n");
		node->right = srRight(node->right);
		node = srLeft(node);
	}

	return node;
}

TreeNode* violation_reculsive(TreeNode* node, int data)
{
	if (node != NULL)
	{
		int b = height(node->left) - height(node->right);
		if (b > 1 || b < -1)
		{
			node = check_violation(node, data);
		}
		node->left = violation_reculsive(node->left, data);
		node->right = violation_reculsive(node->right, data);
	}
	return node;
}

TreeNode* insert(TreeNode* node, int data)
{
	TreeNode* root = node;

	if (root == NULL)
	{
		root = create();
		root->data = data;
	}
	else 
	{
		while (1)
		{
			if (node->data == data)
			{
				break;
			}
			else if (node->data < data)
			{
				if (node->right == NULL)
				{
					node->right = create();
					node->right->data = data;

					break;
				}
				else
				{
					node = node->right;
				}
			}
			else if (node->data > data)
			{
				if (node->left == NULL)
				{
					node->left = create();
					node->left->data = data;

					break;
				}
				else
				{
					node = node->left;
				}
			}
		}
	}

	root = violation_reculsive(root, data);

	return root;
}

TreeNode* find_max(TreeNode* root)
{
	while (root->right != NULL)
	{
		root = root->right;
	}

	return root;
}

TreeNode* erase(TreeNode* node, int data)
{
	TreeNode* temp;
	if (node == NULL)
		printf("Element not there in tree\n");
	else if (data < node->data)
		node->left = erase(node->left, data);
	else if (data > node->data)
		node->right = erase(node->right, data);
	else
	{
		if (node->left && node->right)
		{
			temp = find_max(node->left);
			node->data = temp->data;
			node->left = erase(node->left, node->data);
		}
		else
		{
			temp = node;
			if (node->left == NULL)
				node = node->right;
			else if (node->right == NULL)
				node = node->left;
			free(temp);
		}
	}

	node = violation_reculsive(node, data);

	return node;
}

TreeNode* avl_insert(TreeNode* root, int data)
{
	printf("insert %d\n", data);
	root = insert(root, data);
	inorder(root, 0);
	return root;
}

TreeNode* avl_delete(TreeNode* root, int data)
{
	printf("delete %d\n", data);
	root = erase(root, data);
	inorder(root, 0);
	return root;
}

int main()
{
	TreeNode* root = NULL;
	root = avl_insert(root, 17);
	root = avl_insert(root, 14);
	root = avl_insert(root, 26);
	root = avl_insert(root, 2);
	root = avl_insert(root, 20);
	root = avl_insert(root, 66);
	root = avl_insert(root, 28);

	root = avl_delete(root, 17);
	root = avl_delete(root, 20);
}