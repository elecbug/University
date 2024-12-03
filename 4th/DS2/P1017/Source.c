#include <stdio.h>
#include <stdlib.h>

typedef struct AVLTreeNode {
	int data;
	struct AVLTreeNode* left;
	struct AVLTreeNode* right;
	int height;
} TreeNode;

int Height(TreeNode* root)
{
	if (!root) return -1;
	else return root->height;
}

TreeNode* SingleRotateLeft(TreeNode* X)
{
	TreeNode* W = X->left;
	X->left = W->right;
	W->right = X;
	X->height = max(Height(X->left), Height(X->right)) + 1;
	W->height = max(Height(W->left), Height(W->right)) + 1;
	return W;
}

TreeNode* SingleRotateRight(TreeNode* W)
{
	TreeNode* X = W->right;
	W->right = X->left;
	X->left = W;
	W->height = max(Height(W->left), Height(W->right)) + 1;
	X->height = max(Height(X->left), Height(X->right)) + 1;
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
		printf("%d\n", root->data);
		inorder(root->left);
		inorder(root->right);
	}
}

int test_violation(TreeNode** pnode)
{
	TreeNode* node = *pnode;
	if (node->left != NULL && node->right == NULL && node->left->left != NULL && node->left->right == NULL)
	{
		printf("LL 위반 발생\n");
		*pnode = SingleRotateLeft(node);
		return 1;
	}
	else if (node->right != NULL && node->left == NULL && node->right->right != NULL && node->right->left == NULL)
	{
		printf("RR 위반 발생\n");
		*pnode = SingleRotateRight(node);
		return 1;
	}
	else return 0;
}

int recursive(TreeNode** pnode, int height)
{
	int i1 = 0, i2 = 0, i3 = 0;
	if (pnode != NULL && *pnode != NULL)
	{
		(*pnode)->height = height;
		i1 = test_violation(pnode);
		i2 = recursive(&((*pnode)->left), height + 1);
		i3 = recursive(&((*pnode)->right), height + 1);
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
		roof = recursive(&root, 0);
	}

	inorder(root);
	printf("\n");

	return root;
}

int main()
{
	TreeNode* root = NULL;
	root = insert(root, 5);
	root = insert(root, 4);
	root = insert(root, 3);
	root = insert(root, 2);
	root = insert(root, 1);
	root = insert(root, 6);
	root = insert(root, 7);
	root = insert(root, 8);
	root = insert(root, 9);
	root = insert(root, 10);

}