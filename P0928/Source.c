#include <stdio.h>
#include <stdlib.h>

typedef struct tree_node
{
	int right_thread;
	int left_thread;
	int data;
	struct tree_node* left, * right;
} AVLN;

AVLN* create_node(int data)
{
	AVLN* new_node = malloc(sizeof(AVLN));
	new_node->left = NULL;
	new_node->right = NULL;
	new_node->data = data;
	new_node->right_thread = 0;
	new_node->left_thread = 0;
	return new_node;
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

AVLN* find_inorder_successor(AVLN* p)
{
	AVLN* q = p->right;
	if (q == NULL)
	{
		return q;
	}
	if (p->right_thread == 1)
	{
		return q;
	}
	while (q->left != NULL && q->left_thread == 0)
	{
		q = q->left;
	}
	return q;
}

void thread_inorder(AVLN* root)
{
	AVLN* temp = root;

	while (temp->left != NULL) temp = temp->left;

	do
	{
		printf("%d - ", temp->data);

		temp = find_inorder_successor(temp);

	} while (temp != NULL);
}

AVLN* find_postorder_successor(AVLN* p) 
{
	AVLN* q = p->right;
	if (q == NULL)
	{
		return q;
	}
	if (p->right_thread == 1)
	{
		return q;
	}
	while (q->left != NULL)
	{
		q = q->left;
	}
	return q;
}

void thread_postorder(AVLN* root)
{
	/* ? */
}

int main()
{
	AVLN* node1 = create_node(1);
	AVLN* node2 = create_node(2);
	AVLN* node3 = create_node(3);
	AVLN* node4 = create_node(4);
	AVLN* node5 = create_node(5);
	AVLN* node6 = create_node(6);
	AVLN* node7 = create_node(7);

	make_complete_binary_tree(node1, node2);
	make_complete_binary_tree(node1, node3);
	make_complete_binary_tree(node2, node4);
	make_complete_binary_tree(node2, node5);
	make_complete_binary_tree(node3, node6);
	make_complete_binary_tree(node3, node7);

	node4->right_thread = 1;
	node5->right_thread = 1;
	node6->right_thread = 1;

	node5->left_thread = 1;
	node6->left_thread = 1;
	node7->left_thread = 1;

	node4->right = node2;
	node5->right = node1;
	node6->right = node3;

	node5->left = node2;
	node6->left = node1;
	node7->left = node3;

	thread_inorder(node1);
	thread_postorder(node1);
}