#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} TreeNode;

void make_binary_tree(TreeNode* parent, TreeNode* lson, TreeNode* rson)
{
	parent->left = lson;
	parent->right = rson;
}

void make_complete_binary_tree(TreeNode* parent, TreeNode* son) 
{
	if (parent->left == NULL) 
	{
		parent->left = son;
	}
	else if (parent->right == NULL)
	{
		parent->right = son;
	}
}

TreeNode* create_node(int data)
{
	TreeNode* new_node = malloc(sizeof(TreeNode));
	new_node->left = NULL;
	new_node->right = NULL;
	new_node->data = data;
	return new_node;
}

void recursive_preorder(TreeNode* head)
{
	printf("%d - ", head->data);
	if (head->left != NULL) 
	{
		recursive_preorder(head->left);
	}
	if (head->right != NULL)
	{
		recursive_preorder(head->right);
	}
}

void iterative_preorder(TreeNode* head)
{

}

int main()
{
	TreeNode* head = create_node(0);

	make_complete_binary_tree(head, create_node(1));
	make_complete_binary_tree(head, create_node(2));

	make_complete_binary_tree(head->left, create_node(3));
	make_complete_binary_tree(head->left, create_node(4));

	make_complete_binary_tree(head->right, create_node(5));
	make_complete_binary_tree(head->right, create_node(6));

	recursive_preorder(head);
}