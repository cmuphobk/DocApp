public class Neuron {

	[XmlAttribute("weight")]
	public string data;

	[XmlIgnore]
	public int[,] weight; // веса нейронов
	
	[XmlIgnore]
	public int minimum = 50; // порог
	
	[XmlIgnore]
	public int row = 64,column = 64;

	/**
     * Конструктор нейрона, создает веси и устанавливает случайные значения
     */
	public Neuron()
	{
		weight = new int[row,column];
		randomizeWeights();
	}

	/**
     * ответы нейронов, жесткая пороговая
     * @param input - входной вектор
     * @return ответ 0 или 1
     */
	public int transferHard(int[,] input)
	{
		int power = 0;
		for(int r = 0; r < row;r++)
		{
			for(int c = 0; c < column;c++)
			{
				power += weight[r,c]*input[r,c];
			}
		}
		//Debug.Log("Power: " + power);
		return power >= minimum ? 1 : 0;
	}

	/**
     * ответы нейронов с вероятностями
     * @param input - входной вектор
     * @return n вероятность
     */
	public int transfer(int[,] input)
	{
		int power = 0;
		for(int r = 0; r < row;r++)
			for(int c = 0; c < column;c++)
				power += weight[r,c]*input[r,c];

		//Debug.Log("Power: " + power);
		return power;
	}

	/**
     * устанавливает начальные произвольные значения весам 
     */
	void randomizeWeights()
	{
		for(int r = 0; r < row;r++)
			for(int c = 0; c < column;c++)
				weight[r,c] = Random.Range(0,10);
	}

	/**
     * изменяет веса нейронов
     * @param input - входной вектор
     * @param d - разница между выходом нейрона и нужным выходом
     */
	public void changeWeights(int[,] input,int d)
	{
		for(int r = 0; r < row;r++)
			for(int c = 0; c < column;c++)
				weight[r,c] += d*input[r,c];
	}
}


public class NeuralNetwork {

	[XmlArray("Neurons")]
	public Neuron[] neurons;

	/**
     * Конструктор сети создает нейроны
     */
	public NeuralNetwork()
	{
		neurons = new Neuron[10];

		for(int i = 0;i<neurons.Length;i++)
			neurons[i] = new Neuron();
	}

	/**
     * функция распознавания символа, используется для обучения
     * @param input - входной вектор
     * @return массив из нулей и единиц, ответы нейронов
     */
	int[] handleHard(int[,] input)
	{
		int[] output = new int[neurons.Length];
		for(int i = 0;i<output.Length;i++)
			output[i] = neurons[i].transferHard(input);

		return output;
	}

	/**
     * функция распознавания символа, используется для конечного ответа
     * @param input -  входной вектор
     * @return массив из вероятностей, ответы нейронов
     */
	int[] handle(int[,] input)
	{
		int[] output = new int[neurons.Length];
		for(int i = 0;i<output.Length;i++)
			output[i] = neurons[i].transfer(input);
		
		return output;
	}

	/**
     * ответ сети
     * @param input - входной вектор
     * @return индекс нейронов предназначенный для конкретного символа
     */
	public int getAnswer(int[,] input)
	{
		int[] output = handle(input);
		int maxIndex = 0;
		for(int i = 1; i < output.Length;i++)
			if(output[i] > output[maxIndex])
				maxIndex = i;

		return maxIndex;
	}

	/**
     * функция обучения
     * @param input - входной вектор
     * @param correctAnswer - правильный ответ
     */
	public void study(int[,] input,int correctAnswer)
	{
		int[] correctOutput = new int[neurons.Length];
		correctOutput[correctAnswer] = 1;

		int[] output = handleHard(input);
		while(!compareArrays(correctOutput,output))
		{
			for(int i = 0; i < neurons.Length;i++)
			{
				int dif = correctOutput[i]-output[i];
				neurons[i].changeWeights(input,dif);
			}
			output = handleHard(input);
		}
	}

	/**
     * сравнение двух вектор
     * @param true - если массивы одинаковые, false - если нет
     */
	bool compareArrays(int[] a,int[] b)
	{
		if(a.Length != b.Length)
			return false;

		for(int i = 0;i<a.Length;i++)
			if(a[i] != b[i])
				return false;

		return true;
	}
}