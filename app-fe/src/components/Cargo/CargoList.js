import { useState, useEffect } from "react";
import CardComponentsAll from "../Contenedores/CardComponentsAll.js";
import LoadingBar from "../Inputs/LoadingBar.js";
import TableData from "../Globales/TableData.js";
import ContenidoTabla from "./ContenidoTabla";
import { useCargo } from "@/context/Cargo.Context.js";
import Paginate from "../Globales/Paginate.js";
import Filtros from "./Filtros.js";

function CargoList() {
  const { Cargos } = useCargo();
  const [data, setData] = useState([]);
  const [paginate, setPaginate] = useState(1);
  const [filtros, setFiltros] = useState({
    cargoId: "0",
  });

  useEffect(() => {
    info(paginate);
  }, [filtros, paginate]);

  const info = async () => {
    setData(await Cargos(paginate, filtros));
  };

  const cabeceras = ["Nombre Cargo", "Opciones"];
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
            <Filtros setFiltros={setFiltros}/>

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

export default CargoList;
