#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int is_thread;
	int data;
	struct tree_node* left, * right;
} TreeNode;

TreeNode* create_node(int data)
{
	TreeNode* new_node = malloc(sizeof(TreeNode));
	new_node->left = NULL;
	new_node->right = NULL;
	new_node->data = data;
	return new_node;
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

TreeNode* find_successor(TreeNode* p)
{
	TreeNode* q = p->right;
	if (q == NULL)
	{
		return q;
	}
	if (p->is_thread == 1)
	{
		return q;
	}
	while (q->left != NULL)
	{
		q = q->left;
	}
	return q;
}

void thread_inorder(TreeNode* root)
{
	TreeNode* temp = root;

	while (temp->left != NULL) temp = temp->left;

	do
	{
		printf("%d - ", temp->data);

		temp = find_successor(temp);

	} while (temp != NULL);
}

void thread_postorder(TreeNode* root)
{

}

int main()
{
	TreeNode* node1 = create_node(1);
	TreeNode* node2 = create_node(2);
	TreeNode* node3 = create_node(3);
	TreeNode* node4 = create_node(4);
	TreeNode* node5 = create_node(5);
	TreeNode* node6 = create_node(6);
	TreeNode* node7 = create_node(7);

	make_complete_binary_tree(node1, node2);
	make_complete_binary_tree(node1, node3);
	make_complete_binary_tree(node2, node4);
	make_complete_binary_tree(node2, node5);
	make_complete_binary_tree(node3, node6);
	make_complete_binary_tree(node3, node7);

	node4->is_thread = 1;
	node5->is_thread = 1;
	node6->is_thread = 1;

	node4->right = node2;
	node5->right = node1;
	node6->right = node3;

	thread_inorder(node1);
}