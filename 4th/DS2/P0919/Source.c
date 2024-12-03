#include <stdio.h>
#include <stdlib.h>

typedef int element;

typedef struct node
{
	struct node* prev;
	struct node* next;
	element data;
} NODE;

void init(NODE* head)
{
	head->prev = head; // �ʱ�ȭ���� �ڱ� �ڽ��� ����Ű�� ���� ����Ʈ ��带 ����
	head->next = head;
}

void insert_front(NODE* head, element data) 
{
	if (head->next == head) // �ڱ� �ڽ��� ����Ű��, �� ���Ұ� ���� ��� ù ���� ����
	{
		head->next = (NODE*)malloc(sizeof(NODE));
		head->next->data = data;
		head->next->prev = head;
		head->next->next = NULL;
		head->prev = head->next;
	}
	else // �� ���� ��� �տ��� ���� ����
	{
		NODE* new_node = (NODE*)malloc(sizeof(NODE));
		new_node->prev = head;
		new_node->next = head->next;
		new_node->prev->next = new_node;
		new_node->next->prev = new_node;
		new_node->data = data;
	}
}

void insert_last(NODE* head, element data)
{
	if (head->next == head) // �ڱ� �ڽ��� ����Ű��, �� ���Ұ� ���� ��� ù ���� ����
	{
		head->next = (NODE*)malloc(sizeof(NODE));
		head->next->data = data;
		head->next->prev = head;
		head->next->next = NULL;
		head->prev = head->next;
	}
	else // �� ���� ��� �ڿ��� ���� ����
	{
		NODE* new_node = (NODE*)malloc(sizeof(NODE));
		new_node->next = NULL;
		new_node->prev = head->prev;
		new_node->prev->next = new_node;
		head->prev = new_node;
		new_node->data = data;
	}
}

void show(NODE* head) 
{
	NODE* now = head->next; // ����� ���� ��, ù ���Һ���
	
	while (now != NULL) // null�� ������ �� ���� ��ü ��ȸ
	{
		printf("<-|%d|-> ", now->data);
		now = now->next;
	}
}

int main()
{
	NODE* head1 = (NODE*)malloc(sizeof(NODE));

	init(head1);

	for (int i = 0; i < 5; i++)
	{
		insert_front(head1, i);
		show(head1);
		printf("\n");
	}

	for (int i = 0; i < 5; i++)
	{
		insert_last(head1, i);
		show(head1);
		printf("\n");
	}
}