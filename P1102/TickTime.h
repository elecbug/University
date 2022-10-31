#pragma once

#include <time.h>

typedef struct tick_time
{
	clock_t s_tick;
	clock_t e_tick;
} Tick;

void start(Tick* tick) 
{
	tick->s_tick = clock();
}

void end(Tick* tick)
{
	tick->e_tick = clock();
}

clock_t get_term(Tick* tick)
{
	return tick->e_tick - tick->s_tick;
}