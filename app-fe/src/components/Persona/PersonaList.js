import { useState, useEffect } from "react";
import CardComponentsAll from "../Contenedores/CardComponentsAll.js";
import LoadingBar from "../Inputs/LoadingBar.js";
import TableData from "../Globales/TableData.js";
import ContenidoTabla from "./ContenidoTabla";
import { usePersona } from "@/context/Persona.Context.js";
import Paginate from "../Globales/Paginate.js";
import Filtros from "./Filtros.js";

function PersonaList() {
  const { Persona } = usePersona();
  const [data, setData] = useState([]);
  const [paginate, setPaginate] = useState(1);

  useEffect(() => {
    info();
  }, [paginate]);

  const info = async () => {
    setData(await Persona(paginate));
  };

  const cabeceras = [
    "Nombre",
    "CUI",
    "Telefono",
    "Genero",
    "Direccion",
    "Opciones",
  ];

  if (data.length === 0) {
    return (
      <>
        <CardComponentsAll>
          <div className="w-full max-h-[55vh] overflow-auto">
            <div className="flex items-center justify-center">
              <div className="col-span-12">
                <div className="lg:overflow-visible">
                  <p>No se encontraron datos</p>
                </div>
              </div>
            </div>
          </div>
        </CardComponentsAll>
      </>
    );
  }

  return (
    <CardComponentsAll>
      <div className="w-full">
        {data.length === 0 ? (
          <LoadingBar />
        ) : (
          <>
            <Filtros />

            <div className="max-h-[75vh] overflow-x-auto overflow-visible">
              <TableData cabecera={cabeceras}>
                <ContenidoTabla data={data.records.data} />
              </TableData>
            </div>
          </>
        )}
      </div>
      <Paginate
        paginate={data.pages}
        setPagina={setPaginate}
        pagina={paginate}
      />
    </CardComponentsAll>
  );
}

export default PersonaList;
