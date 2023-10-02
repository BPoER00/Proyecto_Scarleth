function ContenidoTabla({ data }) {
  return (
    <>
      {data.map((d, i) => (
        <tr key={i}>
          <td className="py-4 px-6 text-lg font-medium text-gray-900 whitespace-nowrap dark:text-white text-center">
            {d.nombre}
          </td>
        </tr>
      ))}
    </>
  );
}

export default ContenidoTabla;
