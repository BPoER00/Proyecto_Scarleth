import { usePersona } from "@/context/Persona.Context";
import { useEffect, useState } from "react";
import TableData from "../Globales/TableData";
import FechaConfig from "../../config/fechasMostrar.js";
import Paginate from "../Globales/Paginate";

function InfoModal({ idPersona }) {
  const { Vacunacion } = usePersona();
  const [data, setData] = useState([]);
  const [paginate, setPaginate] = useState(1);

  useEffect(() => {
    info();
  }, [idPersona, paginate]);

  const info = async () => {
    setData(await Vacunacion(paginate, idPersona.toString()));
  };

  console.log(data);
  
  const cabeceras = [
    "Persona Que Vacuno",
    "Cargo",
    "Vacuna",
    "Dosis",
    "Fecha Vacunacion",
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
                {d.asignacion.persona.nombre}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.asignacion.cargo.nombre}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.vacunacion.vacuna.nombre}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {d.dosis}
              </td>
              <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {FechaConfig(d.fecha_vacunacion)}
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
