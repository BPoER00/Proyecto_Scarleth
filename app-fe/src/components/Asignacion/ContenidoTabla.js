function ContenidoTabla({ data }) {
  return (
    <>
      {data.map((d, i) => (
        <tr key={i}>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.numero_colegiado.length > 0
              ? d.numero_colegiado
              : "No Cuenta Con El"}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.persona.nombre}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.cargo.nombre}
          </td>
        </tr>
      ))}
    </>
  );
}

export default ContenidoTabla;
