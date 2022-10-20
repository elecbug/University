#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} AVLN;

void recursive_preorder(AVLN* head)
{
	if (head != NULL)
	{
		recursive_preorder(head->left);
		printf("%d - ", head->data);
		recursive_preorder(head->right);
	}
}

AVLN* create()
{
	AVLN* result = (AVLN*)malloc(sizeof(AVLN));
	result->left = NULL;
	result->right = NULL;

	return result;
}

AVLN* search_BST(AVLN* root, int target)
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

AVLN* insert(AVLN* root, int data)
{
	AVLN* result = root;

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

AVLN* random_BST(int index)
{
	AVLN* result = NULL;
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
		result = insert(result, r);
	}
	printf("\n");
	return result;
}

int main()
{
	int data[] = { 17,2,7,35,12,30 };
	AVLN* root = NULL;

	root = random_BST(7);

	recursive_preorder(root);
}
