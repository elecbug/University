#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int data;
	struct tree_node* left, * right;
} AVLN;

void make_binary_tree(AVLN* parent, AVLN* lson, AVLN* rson)
{
	parent->left = lson;
	parent->right = rson;
}

void make_complete_binary_tree(AVLN* parent, AVLN* son) 
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

AVLN* create_node(int data)
{
	AVLN* new_node = malloc(sizeof(AVLN));
	new_node->left = NULL;
	new_node->right = NULL;
	new_node->data = data;
	return new_node;
}

void recursive_preorder(AVLN* head)
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

void iterative_preorder(AVLN* head)
{

}

int main()
{
	AVLN* head = create_node(0);

	make_complete_binary_tree(head, create_node(1));
	make_complete_binary_tree(head, create_node(2));

	make_complete_binary_tree(head->left, create_node(3));
	make_complete_binary_tree(head->left, create_node(4));

	make_complete_binary_tree(head->right, create_node(5));
	make_complete_binary_tree(head->right, create_node(6));

	recursive_preorder(head);
}