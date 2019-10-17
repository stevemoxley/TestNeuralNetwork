using NeuralNet;
using NeuralNet.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNeuralNetwork
{
    public class InputCSVParser
    {
        public InputCSVParser(int numberOfHiddenLayers, int numberOfNeuronsPerHiddenLayer)
        {
            this._numberOfHiddenLayers = numberOfHiddenLayers;
            this._numberOfNeuronsPerHiddenLayer = numberOfNeuronsPerHiddenLayer;
        }

        public DataPool GetNeuralNetDataPool(string fileName)
        {
            DataPool result = new DataPool();
            result.DataPoints = new List<DataPoint>();
           
            var fileLines = File.ReadAllLines(fileName);

            //File format is
            //Header at the top. Header describes the input and output layers
            //Columns that begin with "i" are input Layers iHungerLevel, iSleepLevel
            //Columns that being with "o" are output Layers, oEat, oSleep
            //We will create a dictionary that

            Dictionary<int, string> columnNames = new Dictionary<int, string>();

            for (int i = 0; i < fileLines.Length; i++)
            {
                if (i == 0)
                {
                    //The header row
                    columnNames = GenerateColumnNameDictionary(fileLines[i]);
                }
                else
                {
                    //Generate the neurons for this network
                    var inputLayer = GenerateInputNeurons(fileLines[i], columnNames);
                    var outputLayer = GenerateOutputNeurons(fileLines[i], columnNames);

                    var dataPoint = new DataPoint();
                    dataPoint.Inputs = inputLayer;
                    dataPoint.Outputs = outputLayer;

                    result.DataPoints.Add(dataPoint);
                }
            }

            return result;
        }

        /// <summary>
        /// Generates the names of the input and output neurons
        /// the int is an index which denotes the row index
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Dictionary<int, string> GenerateColumnNameDictionary(string row)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            var columns = row.Split(',');

            for (int i = 0; i < columns.Length; i++)
            {
                result.Add(i, columns[i]);
            }

            return result;
        }


        private List<Neuron> GenerateInputNeurons(string row, Dictionary<int, string> columnNames)
        {
            List<Neuron> inputNeurons = new List<Neuron>();

            var columns = row.Split(',');

            for (int i = 0; i < columns.Length; i++)
            {
                var columnName = columnNames[i];
                var column = columns[i];

                if (columnName.StartsWith("i") || columnName.StartsWith("I"))
                {
                    double value = double.Parse(column);

                    //Input column
                    inputNeurons.Add(new Neuron
                    {
                        Layer = 0,
                        Name = columnName,
                        Value = value
                    });
                }
            }

            return inputNeurons;
        }

        private List<Neuron> GenerateOutputNeurons(string row, Dictionary<int, string> columnNames)
        {
            List<Neuron> outputNeurons = new List<Neuron>();

            var columns = row.Split(',');

            for (int i = 0; i < columns.Length; i++)
            {
                var columnName = columnNames[i];
                var column = columns[i];

                if (columnName.StartsWith("o") || columnName.StartsWith("O"))
                {
                    double value = double.Parse(column);

                    //Input column
                    outputNeurons.Add(new Neuron
                    {
                        Layer = 0,
                        Name = columnName,
                        Value = value
                    });
                }
            }

            return outputNeurons;
        }


        private int _numberOfHiddenLayers;
        private int _numberOfNeuronsPerHiddenLayer;

    }
}
