import React, { useEffect } from "react";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";
import { useForm } from "react-hook-form";
import { useCargo } from "@/context/Cargo.Context";

function Filtros({ setFiltros }) {
  const { cargo } = useCargo();
  const {
    formState: { errors },
    control,
    watch,
    reset,
  } = useForm();

  const cargoId = (watch("cargo_id") || 0).toString();

  useEffect(() => {
    const filtros = {
      cargoId,
    };

    setFiltros(filtros);
  }, [cargoId]);

  const handleReset = async () => {
    reset();
  };

  return (
    <div className="px-8 pt-6 pb-4 mb-1 dark:bg-gray-800 rounded">
      <div className="flex flex-wrap -mx-4">
        <div className="w-11/12 px-4 mb-4">
          <InputSelect
            label={"Nombre Cargo"}
            name={"cargo_id"}
            options={cargo}
            control={control}
            placeholder={"Cargo..."}
          />
        </div>
        <div className="w-full text-right px-4">
          <button
            type="button"
            className="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded"
            onClick={handleReset}
          >
            Limpiar Campos
          </button>
        </div>
      </div>
    </div>
  );
}

export default Filtros;
