import React, { useEffect } from "react";
import InputSelect from "../Inputs/InputSelect";
import { useForm } from "react-hook-form";
import { useAsignacion } from "@/context/Asignacion.Context";

function Filtros({ setFiltros }) {
  const { persona, cargo } = useAsignacion();
  const {
    formState: { errors },
    control,
    watch,
    reset,
  } = useForm();

  const personaId = (watch("persona_id") || 0).toString();
  const cargoId = (watch("cargo_id") || 0).toString();

  useEffect(() => {
    const filtros = {
      personaId,
      cargoId,
    };

    setFiltros(filtros);
  }, [personaId, cargoId]);

  const handleReset = async () => {
    reset();
  };

  return (
    <div className="px-8 pt-6 pb-4 mb-1 dark:bg-gray-800 rounded">
      <div className="flex flex-wrap -mx-4">
        <div className="w-1/2 px-4 mb-4">
          <InputSelect
            label={"Persona"}
            name={"persona_id"}
            options={persona}
            control={control}
            placeholder={"Persona..."}
          />
        </div>
        <div className="w-1/2 px-4 mb-4">
          <InputSelect
            label={"Cargo"}
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
