#include <stdio.h>
#include <stdlib.h>
#define max(x, y) x > y ? x : y

typedef struct AVLTreeNode {
	int data;
	struct AVLTreeNode* left;
	struct AVLTreeNode* right;
	int height;
} TreeNode;

int height(TreeNode* root)
{
	if (!root) return -1;
	else return root->height;
}

int getBF(TreeNode* node)
{
	return height(node->left) - height(node->right);
}

TreeNode* srLeft(TreeNode* X)
{
	TreeNode* W = X->right;
	X->right = W->left;
	W->left = X;
	X->height = max(height(X->left), height(X->right)) + 1;
	W->height = max(height(W->left), height(W->right)) + 1;
	return W;
}

TreeNode* srRight(TreeNode* W)
{
	TreeNode* X = W->left;
	W->left = X->right;
	X->right = W;
	W->height = max(height(W->left), height(W->right)) + 1;
	X->height = max(height(X->left), height(X->right)) + 1;
	return X;
}

TreeNode* create(TreeNode* parent)
{
	TreeNode* result = (TreeNode*)malloc(sizeof(TreeNode));
	result->left = NULL;
	result->right = NULL;
	if (parent == NULL) result->height = 0;
	else result->height = parent->height + 1;

	return result;
}

void inorder(TreeNode* root)
{
	if (root != NULL)
	{
		for (int i = 0; i < root->height; i++)
		{
			printf("-");
		}
		printf("%2d\n", root->data);
		inorder(root->left);
		inorder(root->right);
	}
}

int test_violation(TreeNode** pnode)
{
	TreeNode* node = *pnode;
	if (getBF(node) == 2 && node->left != NULL && getBF(node->left) == 1)
	{
		// LL
		printf("LL violation\n");
		*pnode = srRight(node);
		return 1;
	}
	else if (getBF(node) == -2 && node->right != NULL && getBF(node->right) == -1)
	{
		// RR
		printf("RR violation\n");
		*pnode = srLeft(node);
		return 1;
	}
	else if (getBF(node) == 0 && node->left != NULL && getBF(node->left) == -1)
	{
		// LR
		printf("LR violation\n");
		node->left = srLeft(node->left);
		*pnode = srRight(node);
		return 1;
	}
	else if (getBF(node) == -2 && node->right != NULL && getBF(node->right) == 1)
	{
		// RL
		printf("RL violation\n");
		node->right = srRight(node->right);
		*pnode = srLeft(node);
		return 1;
	}
	else return 0;
}

int violation(TreeNode** pnode)
{
	int i1 = 0, i2 = 0, i3 = 0;
	if (pnode != NULL && *pnode != NULL)
	{
		i1 = test_violation(pnode);
		i2 = violation(&((*pnode)->left));
		i3 = violation(&((*pnode)->right));
	}

	return i1 | i2 | i3;
}

TreeNode* insert(TreeNode* node, int data)
{
	printf("insert %d\n", data);

	TreeNode* root = node;

	if (root == NULL)
	{
		root = create(NULL);
		root->data = data;
	}
	else {
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
					node->right = create(node);
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
					node->left = create(node);
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

	inorder(root);
	printf("test violation %d\n", data);
	for (int roof = 1; roof == 1; )
	{
		roof = violation(&root);
	}

	inorder(root);
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

}