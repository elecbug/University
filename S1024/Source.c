#include <stdio.h>
#include <stdlib.h>
#define max(x, y) x > y ? x : y

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} TreeNode;

int capacity_inorder(TreeNode* head, int parent_capacity)
{
	if (head != NULL)
	{
		int result = parent_capacity;
		result = max(result, capacity_inorder(head->left, parent_capacity * 2 + 1));
		result = max(result, capacity_inorder(head->right, parent_capacity * 2 + 2));
		
		return result;
	}
	else return 0;
}

void insert_inorder(TreeNode* head, int* arr, int parent_capacity)
{
	if (head != NULL)
	{
		arr[parent_capacity] = head->data;
		insert_inorder(head->left, arr, parent_capacity * 2 + 1);
		insert_inorder(head->right, arr, parent_capacity * 2 + 2);
	}
}

TreeNode* create()
{
	TreeNode* result = (TreeNode*)malloc(sizeof(TreeNode));
	result->left = NULL;
	result->right = NULL;

	return result;
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

int main()
{
	int data[] = { 40,20,80,50,100,70,60 };
	TreeNode* root = NULL;
	for (int i = 0; i < 7; i++)
	{
		root = insert(root, data[i]);
	}

	int capacity = capacity_inorder(root, 0);
	printf("max: %d\n", capacity);
	int* arr = (int*)malloc((capacity + 1) * 4);
	for (int i = 0; i < capacity + 1; i++)
	{
		arr[i] = 0;
	}

	insert_inorder(root, arr, 0);

	for (int i = 0; i < capacity + 1; i++)
	{
		printf("%d -> ", arr[i]);
	}
}
