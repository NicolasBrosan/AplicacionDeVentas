//Aplicacion de venta
const string codigoDeDesodorante = "DES";
const string codigoDeJabonEnPolvo = "JP";
const string codigoDeDetergente = "DET";

const int precioDeDesodorante = 200;
const int precioDeJabonEnPolvo = 300;
const int precioDeDetergente = 250;
var cantidadTotal = 0;

Console.WriteLine("####Bienvenido a la aplicacion de ventas####\n");
Console.WriteLine($"A continuación, detallaremos nuestros productos:\n- Código {codigoDeDetergente} (Detergente) a ${precioDeDetergente}.\n- Código {codigoDeDesodorante}(Desodorante) a ${precioDeDesodorante}.\n- Código {codigoDeJabonEnPolvo} (Jabón en Polvo) a ${precioDeJabonEnPolvo}");
Console.Write("\nIngrese código del producto(DES, JP o DET): ");
var codigoIngresadoPorElCliente = Console.ReadLine();

while (!string.IsNullOrEmpty(codigoIngresadoPorElCliente) && !IsGoodCode(codigoIngresadoPorElCliente))
{
    Console.WriteLine("Se ha ingresado mal el código\n Reingrese el código correcto:");

    codigoIngresadoPorElCliente = Console.ReadLine();
}

if (!string.IsNullOrEmpty(codigoIngresadoPorElCliente))
{
    var precioTotal = ProcessCode(codigoIngresadoPorElCliente);
    cantidadTotal = cantidadTotal + precioTotal;
    Console.WriteLine("\n¿Desea realizar otra compra? Escriba SI para confirmar o escriba NO para terminar.");
}

var input = Console.ReadLine();

while (input != "NO" && input != "SI")
{
    Console.WriteLine("La opcion no es valida. Por favor, vuelva a intentarlo.\n");
    Console.WriteLine("\nDesea realizar otra compra? Escriba SI para confirmar o escriba NO para terminar.");
    input = Console.ReadLine();
}

while (input == "SI")
{
    var precioTotal = 0;
    Console.Write("Ingrese código del producto (DES, JP o DET): ");
    codigoIngresadoPorElCliente = Console.ReadLine();
    while (!string.IsNullOrEmpty(codigoIngresadoPorElCliente) && !IsGoodCode(codigoIngresadoPorElCliente))
    {
        Console.WriteLine("\nSe ha ingresado mal el código\n Reingrese el código correcto:");

        codigoIngresadoPorElCliente = Console.ReadLine();
    }
    if (!string.IsNullOrEmpty(codigoIngresadoPorElCliente))
    {
        precioTotal = ProcessCode(codigoIngresadoPorElCliente);

        cantidadTotal += precioTotal;
        Console.WriteLine("\n¿Desea realizar otra compra? Escriba SI para confirmar o escriba NO para terminar.");
        input = Console.ReadLine();
    }

    while (input != "NO" && input != "SI")
    {
        Console.WriteLine("La opción no es valida. Por favor, vuelva a intentarlo.\n");
        Console.WriteLine("¿Desea realizar otra compra? Escriba SI para confirmar o escriba NO para terminar.");
        input = Console.ReadLine();
    }

}

Console.WriteLine("\nMuchas gracias por su compra. El monto total es: ${0}. Vuelva pronto!", cantidadTotal);


bool IsGoodCode(string code)
{
    return (code.Equals(codigoDeDesodorante) ||
            code.Equals(codigoDeJabonEnPolvo) ||
            code.Equals(codigoDeDetergente));
}

int ProcessCode(string codigo)
{
    var precioTotal = 0;
    Console.Write("\nIngrese cantidad del producto: ");
    int cantidadProducto = Convert.ToInt32(Console.ReadLine());
    precioTotal = GetTotal(cantidadProducto, codigo);

    return precioTotal;
}

int GetTotal(int cantidadProducto, string codigo)
{
    var precio = codigo.Equals(codigoDeDesodorante) ? precioDeDesodorante : codigo.Equals(codigoDeJabonEnPolvo) ? precioDeJabonEnPolvo : precioDeDetergente;
    return precio * cantidadProducto;
}
