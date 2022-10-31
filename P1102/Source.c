/*
A. Linear Search
1. n개의 랜덤한 정수를 발생시켜 배열에 저장
2. 랜덤한 정수 r개를 발생시키고, 각 각을 1번에서 생성한 배열에서 순차 탐색
3. 순차 탐색에 걸린 시간 측정
4. 위 실험을 n이 500,000부터 500,000씩 증가시키면서 10,000,000개 까지 반복, r은 50개 발생

B. BST
A의 과정을 반복하되, n개의 랜덤한 정수를 발생한 뒤 삽입하는 과정과 시간도 측정
n이 500,000부터 500,000씩 증가시키면서 10,000,000개 까지 반복, r은 100,000개 발생

C. AVL
B의 과정과 동일
*/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <time.h>
#include "TickTime.h"
#include "ArrayFunction.h"
#include "BSTFunction.h"
#include "AVLFunction.h"

element random()
{
	srand(time(0) + rand());

	return rand() * rand();
}

clock_t linear_mode(size_t count, int r)
{
	// insert
	Array* arr = create_array(count);
	for (int i = 0; i < count; i++)
	{
		write_array(arr, i, random());
	}

	Tick tick;
	
	// start timer
	start(&tick);

	for (int i = 0; i < r; i++)
	{
		element num = random();

		find_array(arr, num);
	}

	// end timer
	end(&tick);

	printf("배열 %8d개의 데이터에서 %2d회 순차 탐색: %.6llf 초\n", count, r, get_term(&tick) / (double)1000);

	return get_term(&tick);
}

clock_t bst_mode(size_t count, int r)
{
	Tick insert;
	Tick tick;

	// insert start
	start(&insert);

	BSTN* bst = create_BST();
	for (int i = 0; i < count; i++)
	{
		insert_BST(bst, random());
	}

	// insert end
	end(&insert);

	// start timer
	start(&tick);

	for (int i = 0; i < r; i++)
	{
		element num = random();

		search_BST(bst, num);
	}

	// end timer
	end(&tick);

	printf("BST %8d개의 데이터 삽입: %.6llf 초, %6d회 순차 탐색: %.6llf 초, 총 %.6llf 초\n",
		count, r, get_term(&insert) / (double)1000, get_term(&tick) / (double)1000,
		(get_term(&tick) + get_term(&insert)) / (double)1000);

	return get_term(&insert) + get_term(&tick);
}

clock_t avl_mode(size_t count, int r)
{
	Tick insert;
	Tick tick;

	// insert start
	start(&insert);

	AVLN* avl = create_AVL();
	for (int i = 0; i < count; i++)
	{
		insert_AVL(avl, random());
	}

	// insert end
	end(&insert);

	// start timer
	start(&tick);

	for (int i = 0; i < r; i++)
	{
		element num = random();

		search_AVL(avl, num);
	}

	// end timer
	end(&tick);

	printf("AVL %8d개의 데이터 삽입: %.6llf 초, %6d회 순차 탐색: %.6llf 초, 총 %.6llf 초\n",
		count, r, get_term(&insert) / (double)1000, get_term(&tick) / (double)1000,
		(get_term(&tick) + get_term(&insert)) / (double)1000);

	return get_term(&insert) + get_term(&tick);
}

int main()
{
	while (1)
	{
		printf("Select search mode\n 1) Linear(array)\n 2) BST\n 3) AVL\n 4) exit\n>> ");
		switch (getchar())
		{
		case '1': 
		{
			long time[20] = {0};
			
			for (int i = 1; i <= 20; i++)
			{
				time[i - 1] = linear_mode(i * 500000, 50) / 50;
			}

			break;
		}
		case '2':
		{
			long time[20] = { 0 };

			for (int i = 1; i <= 20; i++)
			{
				time[i - 1] = bst_mode(i * 500000, 100000) / 50;
			}

			break;
		}
		case '3':
		{
			long time[20] = { 0 };

			for (int i = 1; i <= 20; i++)
			{
				time[i - 1] = avl_mode(i * 500000, 100000) / 50;
			}

			break;
		}
		case '4': return;
		}
	}
}