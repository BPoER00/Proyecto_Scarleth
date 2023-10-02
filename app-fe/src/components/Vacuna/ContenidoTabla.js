import { useState } from "react";
import Modal from "../Globales/Modal";
import ActionModal from "./ActionModal";
import InfoModal from "./InfoModal";

function ContenidoTabla({ data }) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [modalContent, setModalContent] = useState(null);

  const openModalWithComponent1 = (id) => {
    setModalContent(<InfoModal idVacuna={id} />);
    setIsModalOpen(true);
  };

  const openModalWithComponent2 = (id) => {
    setModalContent(<ActionModal idVacuna={id} />);
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  return (
    <>
      {data.map((d, i) => (
        <tr key={i}>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.nombre}
          </td>
          <td
            className={`py-4 px-6 text-sm font-medium whitespace-nowrap ${
              d.unidades <= 0
                ? "text-red-500 dark:text-red-500"
                : "text-green-500 dark:text-green-500"
            }`}
          >
            {d.unidades}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.cubre}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            {d.dosis}
          </td>
          <td className="py-4 px-6 text-sm font-medium text-gray-900 whitespace-nowrap dark:text-white">
            <div className="flex flex-row">
              <div className="mr-2">
                <button
                  className="group relative h-12 w-12 overflow-hidden rounded-2xl bg-green-500 text-lg font-bold text-white text-center"
                  onClick={() => openModalWithComponent1(d.id)}
                >
                  M
                  <div className="absolute inset-0 h-full w-6 scale-0 rounded-2xl transition-all duration-300 group-hover:scale-100 group-hover:bg-white/30"></div>
                </button>
              </div>
              <div>
                <button
                  className="group relative h-12 w-12 overflow-hidden rounded-2xl bg-yellow-500 text-lg font-bold text-white text-center"
                  onClick={() => openModalWithComponent2(d.id)}
                >
                  N
                  <div className="absolute inset-0 h-full w-full scale-0 rounded-2xl transition-all duration-300 group-hover:scale-100 group-hover:bg-white/30"></div>
                </button>
              </div>
            </div>
          </td>
        </tr>
      ))}
      {isModalOpen && (
        <Modal isOpen={isModalOpen} onClose={closeModal}>
          {modalContent}
        </Modal>
      )}
    </>
  );
}

export default ContenidoTabla;
