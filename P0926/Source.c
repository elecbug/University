#include <stdio.h>
#include <stdlib.h>
#include "Structure.c"

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
	if (head != NULL)
	{
		printf("%d - ", head->data);
		recursive_preorder(head->left);
		recursive_preorder(head->right);
	}
}

void recursive_preorder(AVLN* head)
{
	if (head != NULL)
	{
		recursive_preorder(head->left);
		printf("%d - ", head->data);
		recursive_preorder(head->right);
	}
}

void recursive_postorder(AVLN* head)
{
	if (head != NULL)
	{
		recursive_postorder(head->left);
		recursive_postorder(head->right);
		printf("%d - ", head->data);
	}
}

StackNode* create_stack()
{
	StackNode* top = (StackNode*)malloc(sizeof(StackNode));
	top->next = NULL;
	return top;
}

void push(StackNode* top, AVLN* data)
{
	StackNode* new_node = (StackNode*)malloc(sizeof(StackNode));
	new_node->next = top->next;
	new_node->data = data;
	top->next = new_node;
}

AVLN* pop(StackNode* top)
{
	StackNode* result = top->next->data;
	StackNode* del = top->next;
	top->next = top->next->next;
	free(del);
	return result;
}

void iterative_preorder(AVLN* head)
{
	StackNode* top = create_stack();

	while (1)
	{
		while (head != NULL)
		{
			printf("%d - ", head->data);

			push(top, head);

			head = head->left;
		}
		if (top->next == NULL)
		{
			break;
		}
		else
		{
			head = pop(top);

			head = head->right;
		}
	}
	free(top);
}

void iterative_inorder(AVLN* head)
{
	StackNode* top = create_stack();

	while (1)
	{
		while (head != NULL)
		{
			push(top, head);

			head = head->left;		
		}
		if (top->next == NULL)
		{
			break;
		}
		else
		{
			head = pop(top);

			printf("%d - ", head->data);

			head = head->right;
		}
	}
	free(top);
}

void iterative_postorder(AVLN* head)
{
	StackNode* top = create_stack();

	while (1)
	{
		while (head != NULL)
		{
			if (head->right != NULL)
			{
				push(top, head->right);
			}

			push(top, head);

			head = head->left;
		}
		if (top->next == NULL)
		{
			break;
		}
		else
		{
			head = pop(top);
		}
		if (top->next != NULL && head->right == top->next->data)
		{
			StackNode* temp = head;

			head = pop(top);

			push(top, temp);
		}
		else
		{
			printf("%d - ", head->data);
			head = NULL;
		}
	}
	free(top);
}

int main()
{
	AVLN* head = create_node(1);

	make_complete_binary_tree(head, create_node(2));
	make_complete_binary_tree(head, create_node(3));

	make_complete_binary_tree(head->left, create_node(4));
	make_complete_binary_tree(head->left, create_node(5));

	make_complete_binary_tree(head->right, create_node(6));
	make_complete_binary_tree(head->right, create_node(7));

	recursive_preorder(head);
	printf("\n");
	recursive_preorder(head);
	printf("\n"); 
	recursive_postorder(head);
	printf("\n");
	printf("\n");

	iterative_preorder(head); 
	printf("\n");
	iterative_inorder(head);
	printf("\n");
	iterative_postorder(head);
	printf("\n");
}