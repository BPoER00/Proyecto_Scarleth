function ContenidoTabla({ data }) {
    console.log(data);
    return (
      <>
        {data.map((d, i) => (
            <tr key={i}>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.nombre}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.cui}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.telefono}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.genero.nombre}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.direccion.nombre}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                <button className="group relative h-12 w-48 overflow-hidden rounded-2xl bg-green-500 text-lg font-bold text-white"
                onClick={() => alert(d.id)}
                >
                  Mostrar
                  <div className="absolute inset-0 h-full w-full scale-0 rounded-2xl transition-all duration-300 group-hover:scale-100 group-hover:bg-white/30"></div>
                </button>
              </td>
            </tr>
          ))}
      </>
    );
  }
  
  export default ContenidoTabla;
  