public class Solution {
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums); // worked on leetcode as nums.Sort() probably due to their judging engine
        int cnt = 0;
        int i = 0, j = nums.Length - 1;
        while(i < j) {
            int currentSum = nums[i] + nums[j];
            if(currentSum < k) {
                i++;
            } else if(currentSum > k) {
                j--;
            } else {
                i++; j--;
                cnt++;
            }
        }
        return cnt;
    }
}