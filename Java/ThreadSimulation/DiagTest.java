import java.util.*;
public class DiagTest {
  
  public static void printMatrix(int[][] m) {
    for (int i = 0; i < m.length; i++) {
      for (int j = 0; j < m[0].length; j++) {
        if (j == 0)
          System.out.print("\n" + m[i][j] + " ");
        else
          System.out.print(m[i][j]  + " ");
      }
    }
    System.out.print("\n");
  }
  
  public static void sortPriorityByEchelon(int[] priority, int[] echelon) {
    //end of each segment (group of echelon orders; 5 groups, 5 segments)
    int[] segmentEnd = new int[5];
    int currentEchelon = 0;
    int segmentStart = 0;
    
    //Mark where the group of echelon orders ends (i.e. where 1's stop, where 2's stop)
    for (int i = 0; i < echelon.length; i++) {
      if ((currentEchelon + 1) == echelon[i]) {
        segmentEnd[currentEchelon] = i;
      }
      else if (currentEchelon != segmentEnd.length - 1){
        currentEchelon += 1;
        segmentEnd[currentEchelon] = i;
      }
    }

    //sort priorities
    for (int i = 0; i < segmentEnd.length; i++) {
      if (segmentEnd[i] != 0) {
        Arrays.sort(priority, segmentStart, segmentEnd[i] + 1);
        segmentStart = segmentEnd[i] + 1;
      }
    }
  }
  
  public static void main(String[] args) {
    Random r = new Random();
    
    //int[][] m1 = {{4,3,1}, {7,21,16}};
    //int[][] m2 = {{4,3,1,5,0}, {7,21,16,1,3}};
    
    int[][] test = new int[10][2];
    int[] fiveEch = {1,1,2,2,3,3,4,4,5,5}; //10
    int[] oneEch = {1,1,1,1,1,1,1,1,1,1}; //10
    int[] pri = {9,1,8,2,7,3,6,4,5,1};
    
    sortPriorityByEchelon(pri, fiveEch);
    
    for (int i = 0; i < test.length; i++) {
      test[i][0] = fiveEch[i];
      test[i][1] = pri[i];
    }
    
    printMatrix(test);
    
    /*double f =((r.nextInt(60) + 20)) / 100d;
    f += 1;
    int v = r.nextInt(5000);
    
    double d = f * v;
    int i = (int) d;
    
   System.out.print("Factor: " + f + "\nValue: " + v + "\nInt : " + i + "\nDouble: " + d + "\n");*/
    
    
    //Arrays.sort(m1);
    //Arrays.sort(m2[0], 3, 4);
    
    //System.out.print("Arrays.sort(m1) result:\n");
    //printMatrix(m1);
    
    //System.out.print("\nThread Simulation test result:\n");
    //printMatrix(t.getTable());
    /*for (int i = 0; i < t.getEnds().length; i++)  {
      System.out.print(t.getEnds()[i] + " ");
    }*/
  }
}