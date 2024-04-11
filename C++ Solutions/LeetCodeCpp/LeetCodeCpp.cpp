#include <iostream>
#include "000x_Test.cpp"
#include "0001_TwoSum.cpp"
#include "0217_ContainsDuplicate.cpp"
#include "0242_ValidAnagram.cpp"

int main()
{
    //_0217_ContainsDuplicate solution;
    //std::vector<int> v{ 1,2,3,4 };

    //std::cout << solution.containsDuplicate(v) << std::endl;

    _0001_TwoSum solution;
    std::vector<int> nums{ 2,7,11,15 };
    int target { 9 };

    auto result = solution.twoSum(nums, target);
}
