function ContenidoTabla({ data }) {
  return (
    <>
      {data.map((d, i) => (
        <tr key={i}>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.descripcion}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.persona.nombre}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.dosis}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.vacuna.nombre}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            <div className="flex flex-row">
              <div className="mr-2">
                <button
                  className="group relative h-12 w-12 overflow-hidden rounded-2xl bg-green-500 text-lg font-bold text-white text-center"
                  onClick={() => alert(d.id)}
                >
                  M
                  <div className="absolute inset-0 h-full w-6 scale-0 rounded-2xl transition-all duration-300 group-hover:scale-100 group-hover:bg-white/30"></div>
                </button>
              </div>
              <div>
                <button
                  className="group relative h-12 w-12 overflow-hidden rounded-2xl bg-yellow-500 text-lg font-bold text-white text-center"
                  onClick={() => alert(d.id)}
                >
                  N
                  <div className="absolute inset-0 h-full w-full scale-0 rounded-2xl transition-all duration-300 group-hover:scale-100 group-hover:bg-white/30"></div>
                </button>
              </div>
            </div>
          </td>
        </tr>
      ))}
    </>
  );
}

export default ContenidoTabla;
