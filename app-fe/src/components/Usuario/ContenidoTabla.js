function ContenidoTabla({ data }) {
    return (
      <>
        {data.map((d, i) => (
          <tr key={i}>
            <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
              {d.cui}
            </td>
            <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
              {d.nombreUsuario}
            </td>
            <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
              {d.correo}
            </td>
            <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
              {d.rolNombre}
            </td>
          </tr>
        ))}
      </>
    );
  }
  
  export default ContenidoTabla;
  