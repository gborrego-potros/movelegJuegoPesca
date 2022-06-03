using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using UnityEngine;


public class Sockets : MonoBehaviour
{
    // Sockets Variables
    /*
    

    private static readonly List<Socket> clientSockets = new List<Socket>();

    private const int BUFFER_SIZE = 2048;

    private static readonly byte[] buffer = new byte[BUFFER_SIZE];

    private int port = 5000;
    */
    // Anterior socket
    Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    Socket conexion;
    IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2000);

    // Variables de uso para la terapia
    /*
        // Variable para la calibracion del dispositivo guia
        int porc_disminucion_por_Paro = 5;
        public int NRT = 0, NRR = 0;
        int cont_R = 0, cont_T = 0;

        int[,] PosicionR; //min y max
        double[,] TiemposR; //max->min y de min->max

        int[,] PosicionT;//min y max
        double[,] TiemposT;//max->min y de min->max

        int sumatoria_min_PR = 0, sumatoria_max_PR = 0;
        int sumatoria_min_PT = 0, sumatoria_max_PT = 0;
        double sumatoria_tiempo_mMR = 0, sumatoria_tiempo_MmR = 0;
        double sumatoria_tiempo_mMT = 0, sumatoria_tiempo_MmT = 0;

        double vel_prom_med_RF = 0, vel_prom_med_RE = 0, vel_prom_med_TPF = 0, vel_prom_med_TDF = 0;

        double angulo_rodilla = 0, angulo_cadera = 0, angulo_tobillo = 0;

        public double Promedio_min_PR, Promedio_max_PR, Promedio_min_PT, Promedio_max_PT;
        public double Promedio_mMR, Promedio_MmR, Promedio_mMT, Promedio_MmT;
        public int Porc_Dis_Vel_T, Porc_Dis_Vel_R, Porc_Dis_Des_T, Porc_Dis_Des_R;

        int MCR;

        bool EnProcesoRodilla = false, EnProcesoTobillo = false;
        public int contadorRepRodillaRealizadas = 0, contadorRepTobilloRealizadas = 0;
        public int contadorRepRodillaRealizadasdis = 0, contadorRepTobilloRealizadasdis = 0;


        // Variables para Calculo de posiciones reducidas
        double Desplazamiento, NuevoDesplazamiento, ajuste, NuevaPosicionMaxima, NuevaPosicionMinima;
        double angulo_max_cadera, angulo_max_rodilla, angulo_min_cadera, angulo_min_rodilla;
        double DesplazamientoAngular, NuevoDesplazamientoAngular, ajusteAngular, angulo_max_tobillo, angulo_min_tobillo;

        //Variables para calculo de velocidades reducidas
        double Velocidad_TobilloDF, Velocidad_TobilloPF, Velocidad_RodillaF, Velocidad_RodillaE;

        int VelocidadRodillaE, VelocidadRodillaF, VelocidadAngularDF,VelocidadAngularPF;

        int contador_reducciones = 0;

        //Sesión S1 = new Sesión();
        
    // Variables Extras Auxiliares 
*/
    // Start is called before the first frame update
    async void Start()
    {
       await Task.Run(()=>Server());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Socket Probado
    public void Server()
    {
        serverSocket.Bind(connect);
        serverSocket.Listen(10);

        conexion = serverSocket.Accept();
        Console.WriteLine("Conexion aceptada");

        byte[] recibir_info = new byte[1024];
        string data = "";
        int array_size = 0;
        
        while(true){
        array_size = conexion.Receive(recibir_info, 0, recibir_info.Length, 0);
        Array.Resize(ref recibir_info, array_size);

        data = Encoding.Default.GetString(recibir_info);
        
        Debug.Log("La info recibida es: {0}" + data);
        }
        
        Console.ReadKey();
    }
    /*
    /*-----------------------------Funciones de Calculos de Variables-------------------------------*/
    /*
    public static double Truncate(double value, int decimales)
        {
            double aux_value = Math.Pow(10, decimales);
            return (Math.Truncate(value * aux_value) / aux_value);
        }

        // Se ejecuta exactamente 
        public void Calculo_Angulos(double MV, double Sensor)
        {
            double D1 = 23.5; //Distancias de los dispositivos
            double D2 = 17; //
            double D3 = 7.5; //
            double Dis_CadPared = 76; // Dispositivo Imitador
            double Dis_Sensor = 2; // Dispositivo Guia

            double delta1 = 135; // Angulo inicial de la pierna
            double delta2 = 90; // Angulo de la rodilla 
            double MS = Dis_CadPared - Sensor - Dis_Sensor; //

            // Calculo del angulo bruto de la pierna(Raiz Cuadrada())
            double A = Math.Sqrt(Math.Pow(D1, 2) + Math.Pow(D2, 2) - 2 * D1 * D2 * Math.Cos(delta1 * (Math.PI / 180)));
            
            // Calculo del angulo bruto de la rodilla.
            double B = Math.Sqrt(Math.Pow(D3, 2) + Math.Pow(MS, 2));
            
            //
            double gama1 = Math.Acos(((Math.Pow(B, 2)) + (Math.Pow(MV, 2)) - (Math.Pow(A, 2))) / (2 * B * MV));
            gama1 = gama1 * (180 / Math.PI);// Convierte el resultado a grados

            double gama3 = Math.Asin(MV / A * Math.Sin(gama1 * (Math.PI / 180)));
            gama3 = gama3 * (180 / Math.PI);// Convierte el resultado a grados

            double gama2 = 180 - gama1 - gama3; // Reduccion del angulo final


            double omega1 = Math.Asin(MS / B * Math.Sin(delta2 * (Math.PI / 180)));

            omega1 = omega1 * (180 / Math.PI);// Convierte el resultado a grados

            double omega2 = 180 - omega1 - delta2;

            double beta1 = Math.Asin(D2 / A * Math.Sin(delta1 * (Math.PI / 180)));

            beta1 = beta1 * (180 / Math.PI);// Convierte el resultado a grados

            double beta2 = 180 - beta1 - delta1; // Angulo final reducido

            double teta1 = omega2 + gama1;
            double teta2 = beta1 + gama2;
            double alfa = beta2 + omega1 + gama3;


            double Velocidad_TobilloDF = vel_prom_med_TDF * (100 - Porc_Dis_Vel_T) / 100;
            double Velocidad_TobilloPF = vel_prom_med_TPF * (100 - Porc_Dis_Vel_T) / 100;



            angulo_rodilla = teta2;
            angulo_cadera = teta1;


            //String resultado = "Teta1 = " + teta1 + " , Teta 2 = " + teta2 + " , Alfa = " + alfa;
            //MessageBox.Show(resultado);
        }

        // 
        public void Calc_Val_Reducidas()
        {
            Velocidad_RodillaE = vel_prom_med_RE * (100 - Porc_Dis_Vel_R) / 100;
            Velocidad_RodillaF = vel_prom_med_RF * (100 - Porc_Dis_Vel_R) / 100;
            Velocidad_TobilloDF = vel_prom_med_TDF * (100 - Porc_Dis_Vel_T) / 100;
            Velocidad_TobilloPF = vel_prom_med_TPF * (100 - Porc_Dis_Vel_T) / 100;


            Desplazamiento = Promedio_max_PR - Promedio_min_PR;
            NuevoDesplazamiento = Desplazamiento * (100 - Porc_Dis_Des_R) / 100;
            ajuste = (Desplazamiento - NuevoDesplazamiento) / 2;

            NuevaPosicionMaxima = Promedio_max_PR - ajuste;
            Calculo_Angulos(MCR, NuevaPosicionMaxima);

            angulo_max_cadera = angulo_cadera;
            angulo_max_rodilla = angulo_rodilla;

            NuevaPosicionMinima = Promedio_min_PR + ajuste;
            Calculo_Angulos(MCR, NuevaPosicionMinima);

            angulo_min_cadera = angulo_cadera;
            angulo_min_rodilla = angulo_rodilla;

            DesplazamientoAngular = Promedio_max_PT - Promedio_min_PT;
            NuevoDesplazamientoAngular = DesplazamientoAngular * (100 - Porc_Dis_Des_T) / 100;
            ajusteAngular = (DesplazamientoAngular - NuevoDesplazamientoAngular) / 2;

            angulo_max_tobillo = Promedio_max_PT - ajusteAngular;
            angulo_min_tobillo = Promedio_min_PT + ajusteAngular;
        }


        private void ConversionVelocidadesRodilla() 
        {
            try
            {
                VelocidadRodillaE = Convert.ToInt32(Velocidad_RodillaE);
                VelocidadRodillaF = Convert.ToInt32(Velocidad_RodillaF);

            }
            catch (Exception error) 
            {
                Debug.Log(error.Message);
            }
        }

        private void ConversionVelocidadesTobillo()
        {
            try
            {

                VelocidadAngularDF = Convert.ToInt32(Velocidad_TobilloDF); 
                VelocidadAngularPF = Convert.ToInt32(Velocidad_TobilloPF);
            }
            catch (Exception error)
            {
                Debug.Log(error.Message);
            }
        }
    /************************Funciones para comunicacion WiFi***********************************/
    /*
        private void SetupServer() 
        {
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                serverSocket.Listen(0);
                serverSocket.BeginAccept(AcceptCallback, null);
                Debug.Log("Servidor Listo");
            }
            catch (Exception error) 
            {
                Debug.Log(error.Message);
            }

        }

        private void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;
            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            serverSocket.BeginAccept(AcceptCallback, null);
        }
        
        private void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;
            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Debug.Log("Client forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                clientSockets.Remove(current);
                return;
            }
            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            string[] messagges = text.Split('|');
            try
            {
                //MessageBox.Show(messagges[1]);
                if (messagges[1] == "Tobillo")
                {
                    string[] datos = messagges[2].Split(',');
                    PosicionT[cont_T, 0] = Convert.ToInt32(datos[0]);
                    TiemposT[cont_T, 0] = Convert.ToDouble(datos[2]);
                    PosicionT[cont_T, 1] = Convert.ToInt32(datos[1]);
                    TiemposT[cont_T, 1] = Convert.ToDouble(datos[3]);

                    sumatoria_min_PT = sumatoria_min_PT + PosicionT[cont_T, 1];
                    sumatoria_max_PT = sumatoria_max_PT + PosicionT[cont_T, 0];
                    sumatoria_tiempo_mMT = sumatoria_tiempo_mMT + TiemposT[cont_T, 0];
                    sumatoria_tiempo_MmT = sumatoria_tiempo_MmT + TiemposT[cont_T, 1];

                    cont_T = cont_T + 1;

                    if (cont_T == NRT)
                    {
                        Promedio_min_PT = sumatoria_min_PT / NRT;
                        Promedio_max_PT = sumatoria_max_PT / NRT;
                        Promedio_MmT = sumatoria_tiempo_MmT / NRT;
                        Promedio_mMT = sumatoria_tiempo_mMT / NRT;

                        //Mayor a menor dorsiflexion
                        vel_prom_med_TDF = (Promedio_max_PT - Promedio_min_PT) / Promedio_MmT;
                        vel_prom_med_TPF = (Promedio_max_PT - Promedio_min_PT) / Promedio_mMT;


                        //s1.lbl
                        Debug.Log("Mediciones completas");

                        /*
                        LB_PromDesRodilla.Text = Convert.ToString(Truncate(Promedio_min_PR, 2)) + "-" + Convert.ToString(Truncate(Promedio_max_PR, 2));//"{0:N2} - {1:N2}", Promedio_min_PR , Promedio_max_PR;
                        LB_PromDesTobillo.Text = Convert.ToString(Truncate(Promedio_min_PT, 2)) + "-" + Convert.ToString(Truncate(Promedio_max_PT, 2));//Convert.ToString(Promedio_min_PT) + "-" + Convert.ToString(Promedio_max_PT);
                        LB_PromVelRodilla.Text = Convert.ToString(Truncate(vel_prom_med_RF, 2));//Convert.ToString(vel_prom_med_RF);
                        LB_PromVelRodillaEstiramiento.Text = Convert.ToString(Truncate(vel_prom_med_RE, 2));//Convert.ToString(vel_prom_med_RE);
                        LB_PromVelTobillo.Text = Convert.ToString(Truncate(vel_prom_med_TPF, 2));//Convert.ToString(vel_prom_med_TPF);
                        LB_PromVelTobilloDorsiflexion.Text = Convert.ToString(Truncate(vel_prom_med_TDF, 2));//Convert.ToString(vel_prom_med_TDF);     
                        gb_IniciarTerapia.Enabled = true;
                        */
/*
                    }
    }
    else if (messagges[1] == "Rodilla")
    {
        string[] datos = messagges[2].Split(',');
        PosicionR[cont_R, 0] = Convert.ToInt32(datos[0]) + 2;//+2 posicion del sensor con respecto al centro 
        TiemposR[cont_R, 0] = Convert.ToDouble(datos[2]);
        PosicionR[cont_R, 1] = Convert.ToInt32(datos[1]) + 2;//+2 posicion del sensor con respecto al centro 
        TiemposR[cont_R, 1] = Convert.ToDouble(datos[3]);
        sumatoria_min_PR = sumatoria_min_PR + PosicionR[cont_R, 1];
        sumatoria_max_PR = sumatoria_max_PR + PosicionR[cont_R, 0];
        sumatoria_tiempo_mMR = sumatoria_tiempo_mMR + TiemposR[cont_R, 0];
        sumatoria_tiempo_MmR = sumatoria_tiempo_MmR + TiemposR[cont_R, 1];
        cont_R = cont_R + 1;

        if (cont_R == NRR)
        {
            Promedio_min_PR = sumatoria_min_PR / NRR;
            Promedio_max_PR = sumatoria_max_PR / NRR;
            Promedio_MmR = sumatoria_tiempo_MmR / NRR;
            Promedio_mMR = sumatoria_tiempo_mMR / NRR;

            //Mayor a menor estirar
            vel_prom_med_RE = (Promedio_max_PR - Promedio_min_PR) / Promedio_MmR;
            vel_prom_med_RF = (Promedio_max_PR - Promedio_min_PR) / Promedio_mMR;

            //DialogResult dialogResult = Debug.Log("Comenzar con repeticiones de tobillo", "", MessageBoxButtons.OKCancel);

            /*
            if (dialogResult == DialogResult.OK)
            {
                //Enviar repeticiones de tobillo
                string mensaje = "T," + NRT + "; 0,0,0,0,0,0;0,0,0,0,0,0";
                EnviarRasp(mensaje);

            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //Cancelar repeticiones de tobillo
                string mensaje = "X,0; 0,0,0,0,0,0;0,0,0,0,0,0";
                EnviarRasp(mensaje);
            }*/
       /*
        }
    }
    else if (messagges[1] == "Reduccion")
    {
        try
        {

            //Update Numero Repeticiones
            //ActualizarRepeticiones();
            /*
            DialogResult dialogResult = Debug.Log("Continuar con velocidad y posicion reducidas?", "", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                contador_reducciones++;
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                EnProcesoTobillo = false;
                EnProcesoRodilla = false;
                S1.btn_finalizarsesión.Enabled = true;
                //Enviar mensaje a Raspberry de detener el proceso
            }
            */
/*
            if (EnProcesoRodilla || EnProcesoTobillo)
            {
                /*
                S1.pBx_Happy.Visible = false;
                S1.pBx_Sad.Visible = true;
                *//*
            }

            if (EnProcesoRodilla)
            {
                //S1.pBx_FlechaRodilla.Visible = true;
                //Calcular nuevos limites
                Porc_Dis_Vel_R += porc_disminucion_por_Paro;
                Porc_Dis_Des_R += porc_disminucion_por_Paro;
            }

            else if (EnProcesoTobillo)
            {
                //S1.pBx_FlechaTobillo.Visible = true;
                //Calcular nuevos limites
                Porc_Dis_Vel_T += porc_disminucion_por_Paro;
                Porc_Dis_Des_T += porc_disminucion_por_Paro;
            }

            if (EnProcesoRodilla || EnProcesoTobillo)
            {
                //Calculo de nuevas velocidades y posiciones
                Calc_Val_Reducidas();

                //Crear nuevo Resultados Detallados en DB (reduccion actual)

                //CrearResultadosDetalles(contador_reducciones);



                contadorRepRodillaRealizadasdis = 0;
                contadorRepTobilloRealizadasdis = 0;

                //cambiar etiquetas en Form4
                //fn_actualizar_etiquetas_terapia();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }



    }
    else if (messagges[1] == "RepeticionesTobillo")
    {
        //S1.Lb_repeticionestobillo.Text = messagges[2];
        contadorRepTobilloRealizadas = Convert.ToInt32(messagges[2]);
        contadorRepTobilloRealizadasdis++;

        if (contadorRepTobilloRealizadas == NRT)
        {
            EnProcesoTobillo = false;
            //actualizar datos de tobillo
            //ActualizarRepeticiones();

            //S1.btn_finalizarsesión.Enabled = true;


        }

    }
    else if (messagges[1] == "RepeticionesRodilla")
    {
        //S1.Lb_repeticionesrodilla.Text = messagges[2];
        contadorRepRodillaRealizadas = Convert.ToInt32(messagges[2]);
        contadorRepRodillaRealizadasdis++;
        if (contadorRepRodillaRealizadas == NRR)
        {
            EnProcesoRodilla = false;

            //actualizar datos de rodilla
            //ActualizarRepeticiones();


        }

    }
    else if (messagges[1] == "En posicion") 
    {
        //DialogResult dialogResult = MessageBox.Show("Comenzar con repeticiones de tobillo?", "", MessageBoxButtons.OKCancel);
        /*
        if (dialogResult == DialogResult.OK)
        {
            EnProcesoTobillo = true;
            ConversionVelocidadesTobillo();
            string mensaje = "X,0;0,0,0,0,0,0;"+ VelocidadAngularPF+","+VelocidadAngularDF+","+angulo_min_tobillo+","+angulo_max_tobillo+",0,"+NRT;
            EnviarRasp(mensaje);

        }
        else if (dialogResult == DialogResult.Cancel)
        {
            EnProcesoTobillo = false;
        }*//*
    }
    else
    {
       Debug.Log("Received Text: " + messagges[1]);
    }
}
catch (Exception e)
{
    Debug.Log(e.Message);
}
current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
}

private void EnviarRasp(string mensaje) 
{
foreach (Socket client_Socket in clientSockets)
{

    int byteCount = Encoding.ASCII.GetByteCount(mensaje); //Measures bytes required to send ASCII data
    byte[] sendData = new byte[byteCount]; //Prepares variable size for required data
    sendData = Encoding.ASCII.GetBytes(mensaje); //Sets the sendData variable to the actual binary dat
    client_Socket.Send(sendData);
}
}
*/
}
