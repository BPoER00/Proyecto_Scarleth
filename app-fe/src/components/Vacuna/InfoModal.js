import { useEffect, useState } from "react";
import TableData from "../Globales/TableData";
import FechaConfig from "../../config/fechasMostrar.js";
import Paginate from "../Globales/Paginate";
import { useVacuna } from "@/context/Vacuna.Context";

function InfoModal({ idVacuna }) {
  const { VacunaDetalle } = useVacuna();
  const [data, setData] = useState([]);
  const [paginate, setPaginate] = useState(1);

  useEffect(() => {
    info();
  }, [idVacuna, paginate]);

  const info = async () => {
    setData(await VacunaDetalle(paginate, idVacuna.toString()));
  };

  console.log(data);

  const cabeceras = [
    "Fecha Ingreso",
    "Cantidad",
    "Descripcion",
    "Fecha Vencimiento",
  ];

  if (data.length === 0) {
    return (
      <>
        <div className="w-full max-h-[55vh] overflow-auto">
          <div className="flex items-center justify-center">
            <div className="col-span-12">
              <div className="lg:overflow-visible">
                <p>No se encontraron datos</p>
              </div>
            </div>
          </div>
        </div>
      </>
    );
  }

  return (
    <>
      <div className="max-h-[75vh] overflow-x-auto overflow-visible">
        <TableData cabecera={cabeceras}>
          {data.records.data.map((d, i) => (
            <tr key={i}>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {FechaConfig(d.createAt)}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.cantidad}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.descripcion}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {FechaConfig(d.fecha_vencimiento)}
              </td>
            </tr>
          ))}
        </TableData>
      </div>
      <Paginate
        paginate={data.pages}
        setPagina={setPaginate}
        pagina={paginate}
      />
    </>
  );
}

export default InfoModal;
