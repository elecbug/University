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
		for (int i = 0; i < height; i++)
		{
			printf("-");
		}
		printf("%2d\n", root->data);
		inorder(root->left, height + 1);
		inorder(root->right, height + 1);
	}
}

void check_violation(TreeNode** pnode, int data)
{
	TreeNode* node = *pnode;
	int balance = height(node->left) - height(node->right);

	if (balance > 1 && node->left->data > data)
	{
		// LL
		printf("LL violation\n");
		*pnode = srRight(node);
	}
	else if (balance < -1 && node->right->data < data)
	{
		// RR
		printf("RR violation\n");
		*pnode = srLeft(node);
	}
	else if (balance > 1 && node->left->data < data)
	{
		// LR
		printf("LR violation\n");
		node->left = srLeft(node->left);
		*pnode = srRight(node);
	}
	else if (balance < -1 && node->right->data > data)
	{
		// RL
		printf("RL violation\n");
		node->right = srRight(node->right);
		*pnode = srLeft(node);
	}
}

TreeNode* violation_reculsive(TreeNode* node, int data)
{
	if (node != NULL)
	{
		int b = height(node->left) - height(node->right);
		if (b > 1 || b < -1)
		{
			check_violation(&node, data);
		}
		node->left = violation_reculsive(node->left, data);
		node->right = violation_reculsive(node->right, data);
	}
	return node;
}

TreeNode* insert(TreeNode* node, int data)
{
	printf("insert %d\n", data);

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

	inorder(root, 0);
	printf("\n");

	return root;
}

int main()
{
	TreeNode* root = NULL;
	/*root = insert(root, 17);
	root = insert(root, 14);
	root = insert(root, 2);
	root = insert(root, 26);
	root = insert(root, 20);
	root = insert(root, 66);
	root = insert(root, 28);*/
	root = insert(root, 1);
	root = insert(root, 2);
	root = insert(root, 3);
	root = insert(root, 4);
	root = insert(root, 5);
	root = insert(root, 6);
	root = insert(root, 7);
}