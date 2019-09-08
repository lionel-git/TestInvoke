#include "calculator.h"

#include <windows.h>
#include <iostream>
#include <libloaderapi.h>


calculator::calculator()
{
}

typedef double(* MYPROC)(double a, double b);


MYPROC current_function;

int load_library()
{
	HINSTANCE hGetProcIDDLL = LoadLibrary(L"SubLibrary.dll");

	if (!hGetProcIDDLL) {
		std::cout << "could not load the dynamic library" << std::endl;
		return EXIT_FAILURE;
	}

	// resolve function address here
	current_function = (MYPROC)GetProcAddress(hGetProcIDDLL, "do_sum");
	if (!current_function) {
		std::cout << "could not locate the function" << std::endl;
		return EXIT_FAILURE;
	}

	//auto w = current_function(4.0, 7.0);
	

	return EXIT_SUCCESS;
}


double calculator::do_sum(double a, double b)
{
	try {
	/*	char* P = 0;
		*P = 'a';*/

		load_library();
		return current_function(a, b);
	}
	catch (std::exception e)
	{
		std::cout << e.what() << std::endl;
		return -5;
	}
	catch (...)
	{
		return -17;
	}
	//return a + b;
}
