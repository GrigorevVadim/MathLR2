namespace Task3
{
    public static class GaussTables
    {
        public static double[,] CreateTableT()
        {
            var table = new double[6, 6];

            table[0,0] = 0;

            table[1,0] = -0.57735027;
            table[1,1] = 0.57735027;

            table[2,0] = -0.77459667;
            table[2,1] = 0;
            table[2,2] = 0.77459667;

            table[3,0] = -0.86113631;
            table[3,1] = -0.33998104;
            table[3,2] = 0.33998104;
            table[3,3] = 0.86113631;

            table[4,0] = -0.90617985;
            table[4,1] = -0.53846931;
            table[4,2] = 0;
            table[4,3] = 0.53846931;
            table[4,4] = 0.90617985;

            table[5,0] = -0.932469515;
            table[5,1] = -0.66120939;
            table[5,2] = -0.23861919;
            table[5,3] = 0.23861919;
            table[5,4] = 0.66120939;
            table[5,5] = 0.932469515;

            return table;
        }
        
        public static double[,] CreateTableA()
        {
            var table = new double[6, 6];

            table[0,0] = 2;

            table[1,0] = 1;
            table[1,1] = 1;

            table[2,0] = 0.55555556;
            table[2,1] = 0.88888889;
            table[2,2] = 0.55555556;

            table[3,0] = 0.34785484;
            table[3,1] = 0.65214516;
            table[3,2] = 0.65214516;
            table[3,3] = 0.34785484;

            table[4,0] = 0.23692688;
            table[4,1] = 0.47862868;
            table[4,2] = 0.56888889;
            table[4,3] = 0.47862868;
            table[4,4] = 0.23692688;

            table[5,0] = 0.17132450;
            table[5,1] = 0.36076158;
            table[5,2] = 0.46791394;
            table[5,3] = 0.46791394;
            table[5,4] = 0.36076158;
            table[5,5] = 0.17132450;

            return table;
        }
    }
}