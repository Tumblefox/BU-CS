public class SingleThreadSim implements Runnable {
/**
 * Runs simulation in just one thread
 * @author A'Jee Sieka
**/ 
  private int[][] table;
  private String report;
  private String file;
/**
 * Constuctor
 * @param simTable The generated table
**/ 
  public SingleThreadSim(int[][] simTable) {
    table = simTable;
    report = "";
    file = "";
  }
/**
 * Simulates running each process in the table and writes a report when the simulation has been completed
**/
  public void run() {
    for (int i = 0; i < table.length; i++) {
      try {
        long startTime = System.currentTimeMillis();
        Thread.sleep(table[i][3]);
        long endTime = System.currentTimeMillis();
        
        System.out.print("Request " + table[i][2] + " Processed\n");
        report += "Echelon: " + table[i][0] + " Priority: " + table[i][1] + " Request: " + table[i][2]
          + " Start (ms): " + startTime + " End (ms): " + endTime + " Processing Time (ms): " + table[i][3] + "\n";
        
        file += table[i][0] + "," + table[i][1] + "," + table[i][2] + "," + startTime + "," + endTime + ","
          + table[i][3] + "\n";
      }
      catch (Exception e) {
      }
    }
    System.out.print(report);
  }
/**
 * Writes a file-ready report for the simulation in .csv format
 * @return Returns the file-string
**/
  public String getReport() {
    String s = "";
    s += "Echelon,Priority,Request-Code,Begin-Time,End-Time,Processing-Time(MS),\n";
    s += file;
    return s;
  }
}