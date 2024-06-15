using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using System;

public class NpcRndomLog : MonoBehaviour
{
    public GameObject log1; // Log1을 드래그 앤 드롭으로 할당
    public GameObject log2; // Log2를 드래그 앤 드롭으로 할당
    public GameObject log3; // Log3을 드래그 앤 드롭으로 할당

    private GameObject[] logs;
    private GameObject activeLog;

    void Start()
    {
        // logs 배열에 Log 오브젝트들을 할당합니다.
        logs = new GameObject[] { log1, log2, log3 };

        // 모든 로그를 시작 시 비활성화합니다.
        foreach (var log in logs)
        {
            if (log != null)
            {
                log.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ActivateRandomLog();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            DeactivateLog();
        }
    }

    void ActivateRandomLog()
    {
        if (logs.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, logs.Length);
            activeLog = logs[randomIndex];
            activeLog.SetActive(true);
        }
    }

    void DeactivateLog()
    {
        if (activeLog != null)
        {
            activeLog.SetActive(false);
            activeLog = null;
        }
    }
}
