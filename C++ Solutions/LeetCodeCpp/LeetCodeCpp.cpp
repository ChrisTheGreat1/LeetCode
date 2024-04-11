#include <iostream>
#include "000x_Test.cpp"
#include "0217_ContainsDuplicate.cpp"

int main()
{
    //_0217_ContainsDuplicate obj;
    //obj.run();

    _0217_ContainsDuplicate solution;
    std::vector<int> v{ 1,2,3,4 };

    std::cout << solution.containsDuplicate(v) << std::endl;
}
